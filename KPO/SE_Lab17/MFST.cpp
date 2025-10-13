#include <iostream>
#include <iomanip>
#include "stdafx.h"
#include "MFST.h"
#include "Error.h"
#include "GRB.h"

using namespace std;

int FST_TRACE_n = -1;
char rbuf[205];
char sbuf[205];
char lbuf[1024];



namespace MFST
{

    MfstState::MfstState()
    {
        lenta_position = 0;
        nrule = -1;
        nrulechain = -1;
    }

    MfstState::MfstState(short pposition, MFSTSTSTACK pst, short pnrulechain)
    {
        lenta_position = pposition;
        st = pst;
        nrulechain = pnrulechain;
    }

    MfstState::MfstState(short pposition, MFSTSTSTACK pst, short pnrule, short pnrulechain)
    {
        lenta_position = pposition;
        st = pst;
        nrule = pnrule;
        nrulechain = pnrulechain;   // ✅ исправлено
    }

    // --------------------------- MfstDiagnosis ---------------------------

    Mfst::MfstDiagnosis::MfstDiagnosis()
    {
        lenta_position = -1;
        nrule = -1;
        nrule_chain = -1;
        rc_step = SURPRISE;
    }

    Mfst::MfstDiagnosis::MfstDiagnosis(short plenta_position, RC_STEP prc_step, short pnrule, short pnrule_chain)
    {
        lenta_position = plenta_position;
        rc_step = prc_step;
        nrule = pnrule;
        nrule_chain = pnrule_chain;
    }

    // --------------------------- Mfst ---------------------------

    Mfst::Mfst()
    {
        lenta = 0;
        lenta_size = lenta_position = 0;
    };

    Mfst::Mfst(LT::LexTable plex, GRB::Greibach pgrebach)
    {
        grebach = pgrebach;
        lex = plex;
        lenta = new short[lenta_size = lex.size];
        for (int k = 0; k < lenta_size; k++)
        {
            lenta[k] = TS(lex.table[k].lexema[0]);
        }
        lenta[lex.size] = TS('$');
        lenta_position = 0;
        st.push(grebach.stbottomT);
        st.push(grebach.startN);
        nrulechain = -1;
    };

    Mfst::RC_STEP Mfst::step()
    {
        RC_STEP rc = SURPRISE;

        //cout << "DEBUG: lenta[" << lenta_position << "] = "
        //    << GRB::Rule::Chain::alphabet_to_char(lenta[lenta_position])
        //    << ", stack top = "
        //    << GRB::Rule::Chain::alphabet_to_char(st.top())
        //    << endl;


        if (lenta_position < lenta_size)
        {

            if (ISNS(st.top()))
            {
                GRB::Rule rule;
                if ((nrule = grebach.getRule(st.top(), rule)) >= 0)
                {
                    GRB::Rule::Chain chain;
                    if ((nrulechain = rule.getNextChain(lenta[lenta_position], chain, nrulechain + 1)) >= 0)
                    {
                        MFST_TRACE1
                            savestate();
                        st.pop();
                        push_chain(chain);
                        rc = NS_OK;
                        MFST_TRACE2
                    }
                    else
                    {
                        MFST_TRACE4("TNS_NORULECHAIN_NORULE")
                            savediagnosis(NS_NORULECHAIN);
                        rc = reststate() ? NS_NORULECHAIN : NS_NORULE;
                    }
                }
                else
                {
                    rc = NS_ERROR;
                }
            }
            else if ((st.top() == lenta[lenta_position]))
            {
                lenta_position++;
                st.pop();
                nrulechain = -1;
                rc = TS_OK;
                MFST_TRACE3
            }
            else {
                MFST_TRACE4("TS_NOK/NS_NORULECHAIN")
                    rc = reststate() ? TS_NOK : NS_NORULECHAIN;
            }
        }
        else {
            rc = LENTA_END;
            MFST_TRACE4("LENTA_END")
        }
        return rc;
    };

    bool Mfst::push_chain(GRB::Rule::Chain chain)
    {
        for (int k = chain.size - 1; k >= 0; k--)
        {
            st.push(chain.nt[k]);
        }
        return true;
    };

    bool Mfst::savestate()
    {
        storestate.push(MfstState(lenta_position, st, nrule, nrulechain));
        MFST_TRACE6("SAVESTATE", storestate.size());
        return true;
    };

    bool Mfst::reststate()
    {
        bool rc = false;
        MfstState state;

        if (rc = (storestate.size() > 0))
        {
            state = storestate.top();
            lenta_position = state.lenta_position;
            st = state.st;
            nrule = state.nrule;
            nrulechain = state.nrulechain;
            storestate.pop();
            MFST_TRACE5("RESSTATE")
                MFST_TRACE2
        }
        return rc;
    };

    bool Mfst::savediagnosis(RC_STEP prc_step)
    {
        bool rc = false;
        short k = 0;
        while (k < MFST_DIAGN_NUMBER && lenta_position <= diagnosis[k].lenta_position)
        {
            k++;
        }
        if (rc = (k < MFST_DIAGN_NUMBER))
        {
            diagnosis[k] = MfstDiagnosis(lenta_position, prc_step, nrule, nrulechain);
            for (short j = k + 1; j < MFST_DIAGN_NUMBER; j++)
            {
                diagnosis[j].lenta_position = -1;
            }
        }
        return rc;
    };

    bool Mfst::start()
    {
        bool rc = false;
        RC_STEP rc_step = SURPRISE;
        char buf[MFST_DIAGN_MAXSIZE];
        rc_step = step();
        while (rc_step == NS_OK || rc_step == NS_NORULECHAIN || rc_step == TS_OK || rc_step == TS_NOK)
        {
            cout << "DEBUG: step start" << endl;
            rc_step = step();
        }

        switch (rc_step)
        {
        case LENTA_END:      MFST_TRACE4("------>LENTA_END")
            cout << "-------------------------------------------------------------------------- ----" << endl;
            sprintf_s(buf, MFST_DIAGN_MAXSIZE, "%d: всего строк %d, синтаксический анализ выполнен без ошибок", 0, lenta_size);
            cout << setw(4) << left << 0 << ": всего строк " << lenta_size << ", синтаксический анализ выполнен без ошибок" << endl;
            rc = true;
            break;
        case NS_NORULE:     MFST_TRACE_MSG("------>NS_NORULE")
            cout << "-------------------------------------------------------------------------- ----" << endl;
            for (int d = 0; d < MFST_DIAGN_NUMBER; ++d) {
                if (diagnosis[d].lenta_position >= 0) {
                    cout << getDiagnosis(d, buf) << endl;
                }
            }
            break;
        case NS_NORULECHAIN:
            MFST_TRACE_MSG("------>NS_NORULECHAIN")
                cout << "Нет подходящей цепочки правил." << endl;
            for (int d = 0; d < MFST_DIAGN_NUMBER; ++d) if (diagnosis[d].lenta_position >= 0) cout << getDiagnosis(d, buf) << endl;
            break;

        case NS_ERROR:
            MFST_TRACE_MSG("------>NS_ERROR")
                cout << "Ошибка: нет правила для нетерминала." << endl;
            for (int d = 0; d < MFST_DIAGN_NUMBER; ++d) if (diagnosis[d].lenta_position >= 0) cout << getDiagnosis(d, buf) << endl;
            break;
        case SURPRISE:
            MFST_TRACE_MSG("------>SURPRISE")
                cout << "Неожиданное состояние." << endl;
            for (int d = 0; d < MFST_DIAGN_NUMBER; ++d) if (diagnosis[d].lenta_position >= 0) cout << getDiagnosis(d, buf) << endl;
            break;
        }
        return rc;
    };

    char* Mfst::getCSt(char* buf)
    {
        int sz = (int)st.size();
        for (int k = 0; k < sz; ++k)
        {
            short p = st.c[sz - 1 - k];    // выводим от верхушки вниз
            buf[k] = GRB::Rule::Chain::alphabet_to_char(p);
        }
        buf[sz] = '\0';
        return buf;
    };

    char* Mfst::getCLenta(char* buf, short pos, short n)
    {
        if (pos >= lenta_size) { buf[0] = '\0'; return buf; }
        short i, k = (pos + n < lenta_size) ? pos + n : lenta_size;
        short out = 0;
        for (i = pos; i < k; i++)
        {
            buf[out++] = GRB::Rule::Chain::alphabet_to_char(lenta[i]);
        }
        buf[out] = '\0';
        return buf;
    };

    char* Mfst::getDiagnosis(short n, char* buf)
    {
        char* rc = const_cast<char*>("");
        int errid = 0;
        int lpos = -1;
        if (n < MFST_DIAGN_NUMBER && (lpos = diagnosis[n].lenta_position) >= 0)
        {
            errid = grebach.getRule(diagnosis[n].nrule).iderror;
            Error::ERROR err = Error::geterror(errid);
            sprintf_s(buf, MFST_DIAGN_MAXSIZE, "%d: строка %d, %s", err.id, lex.table[lpos].sn, err.message);
            rc = buf;
        }
        return rc;
    };

    void  Mfst::printrules()
    {
        MfstState state;
        GRB::Rule rule;
        for (unsigned short k = 0; k < storestate.size(); k++)
        {
            state = storestate.c[k];
            rule = grebach.getRule(state.nrule);
            MFST_TRACE7
        }
    };

    bool Mfst::savededucation()
    {
        MfstState state;
        GRB::Rule rule;
        deducation.nrules = new short[deducation.size = storestate.size()];
        deducation.nrulechains = new short[deducation.size];
        for (unsigned short k = 0; k < storestate.size(); k++)
        {
            state = storestate.c[k];
            deducation.nrules[k] = state.nrule;
            deducation.nrulechains[k] = state.nrulechain;
        }
        return true;
    }

}
