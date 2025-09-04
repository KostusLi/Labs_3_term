#pragma once
#define IN_MAX_LEN_TEXT 1024*1024
#define IN_CODE_ENDL '\n'

namespace In
{
  struct IN
  {
    enum { T = 1024, F = 2048, I = 4096 };
    int size;                     
    int lines;                    
    int ignor;                   
    unsigned char* text;          



    int code[256] = { 
  IN::F, IN::F, IN::F, IN::T, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F,  '|' , IN::F, IN::F, IN::T, IN::F, IN::F,
  IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F,
  IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F,
  IN::T, IN::F, IN::T, IN::F, IN::F, IN::F, IN::F, IN::T, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F,
  IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::T, IN::F, IN::F, IN::T, IN::F, IN::F, IN::F, IN::F,
  IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::I,  '!' , IN::F, IN::F, IN::F, IN::F, IN::F, IN::F,
  IN::F, IN::T, IN::F, IN::T, IN::F, IN::T, IN::F, IN::F, IN::T, IN::T, IN::F, IN::T, IN::F, IN::F, IN::F, IN::T,
  IN::F, IN::F, IN::F, IN::T, IN::T, IN::F, IN::T, IN::F, IN::F, IN::T, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F,
                                                          
  IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F,
  IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::T, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F,
  IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F,
  IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F,
    '-', IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::T, IN::F, IN::F, IN::F, IN::F, IN::F,
  IN::F, IN::F, IN::F, IN::F, IN::F, IN::I, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F,
  IN::T, IN::F, IN::T, IN::F, IN::F, IN::T, IN::F, IN::F, IN::T, IN::F, IN::T, IN::F, IN::F, IN::F, IN::T, IN::F,
  IN::F, IN::T, IN::T, IN::F, IN::F, IN::F, IN::F, IN::T, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::T,
    };

  };
  IN getin(wchar_t infile[]);   
};
