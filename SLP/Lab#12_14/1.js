class Sudoku {
    constructor() {
        this.initialBoard = Array.from({ length: 9 }, () => Array(9).fill(0));
        this.board = this.copyBoard(this.initialBoard);
        this.fixedCells = new Set();
    }

    copyBoard(board) {
        return board.map(row => [...row]);
    }

    resetBoard() {
        this.board = this.copyBoard(this.initialBoard);
        this.fixedCells.clear();
        fillBoard("board", this.board);
        this.clearFixedStyles();
        console.log("Поле сброшено до исходного состояния.");
    }

    clearFixedStyles() {
        document.querySelectorAll("#board td").forEach(td => {
            td.classList.remove("fixed-cell");
        });
    }

    generatePartialBoard() {
        this.board = Array.from({ length: 9 }, () => Array(9).fill(0));
        this.fixedCells.clear();
        this.clearFixedStyles();

        let filled = 0;
        let attempts = 0;

        while (filled < 10 && attempts < 1000) {
            attempts++;
            const row = Math.floor(Math.random() * 9);
            const col = Math.floor(Math.random() * 9);
            const num = Math.floor(Math.random() * 9) + 1;

            if (this.board[row][col] === 0 && this.isValid(row, col, num)) {
                this.board[row][col] = num;
                this.fixedCells.add(`${row},${col}`);
                filled++;
            }
        }

        fillBoard("board", this.board);
        console.log(`Сгенерировано ${filled} корректных чисел.`);

        document.querySelectorAll("#board td").forEach(td => {
            const r = td.getAttribute("data-row");
            const c = td.getAttribute("data-col");
            if (this.fixedCells.has(`${r},${c}`)) {
                td.classList.add("fixed-cell");
            }
        });
    }


    checkRows() {
        let errorRows = [];
        for (let i = 0; i < 9; i++) {
            let nums = new Set();
            for (let j = 0; j < 9; j++) {
                let val = this.board[i][j];
                if (val !== 0) {
                    if (nums.has(val)) {
                        errorRows.push(i);
                        break;
                    }
                    nums.add(val);
                }
            }
        }
        return errorRows;
    }

    checkColumns() {
        let errorCols = [];
        for (let j = 0; j < 9; j++) {
            let nums = new Set();
            for (let i = 0; i < 9; i++) {
                let val = this.board[i][j];
                if (val !== 0) {
                    if (nums.has(val)) {
                        errorCols.push(j);
                        break;
                    }
                    nums.add(val);
                }
            }
        }
        return errorCols;
    }

    checkSquares() {
        let errorSquares = [];
        for (let row = 0; row < 9; row += 3) {
            for (let col = 0; col < 9; col += 3) {
                let nums = new Set();
                let hasError = false;
                for (let i = 0; i < 3; i++) {
                    for (let j = 0; j < 3; j++) {
                        let val = this.board[row + i][col + j];
                        if (val !== 0) {
                            if (nums.has(val)) {
                                hasError = true;
                            }
                            nums.add(val);
                        }
                    }
                }
                if (hasError) errorSquares.push([row, col]);
            }
        }
        return errorSquares;
    }

    checkAll() {
        clearHighlights();
        console.log("Проверка всего поля...");

        const errorRows = this.checkRows();
        const errorCols = this.checkColumns();
        const errorSquares = this.checkSquares();

        let hasError = errorRows.length > 0 || errorCols.length > 0 || errorSquares.length > 0;

        if (hasError) {
            highlightErrors(errorRows, errorCols, errorSquares);
            console.log("Обнаружены ошибки.");
        } else {
            highlightCorrect();
            console.log("Ошибок не найдено!");
        }
    }

    generateSolvedBoard() {
        this.board = Array.from({ length: 9 }, () => Array(9).fill(0));
        this.fixedCells.clear();
        this.clearFixedStyles();

        this.solve(0, 0);
        this.printBoard();
        fillBoard("board", this.board);
    }

    solve(row, col) {
        if (row === 9) return true;
        if (col === 9) return this.solve(row + 1, 0);

        let numbers = [1,2,3,4,5,6,7,8,9].sort(() => Math.random() - 0.5);
        for (let num of numbers) {
            if (this.isValid(row, col, num)) {
                this.board[row][col] = num;
                if (this.solve(row, col + 1)) return true;
                this.board[row][col] = 0;
            }
        }
        return false;
    }

    isValid(row, col, num) {
        for (let x = 0; x < 9; x++) {
            if (this.board[row][x] === num) return false;
        }
        for (let y = 0; y < 9; y++) {
            if (this.board[y][col] === num) return false;
        }
        let startRow = Math.floor(row / 3) * 3;
        let startCol = Math.floor(col / 3) * 3;
        for (let i = 0; i < 3; i++) {
            for (let j = 0; j < 3; j++) {
                if (this.board[startRow + i][startCol + j] === num) return false;
            }
        }
        return true;
    }

    generateBoard() {
        this.fixedCells.clear();
        this.clearFixedStyles();

        for (let i = 0; i < 9; i++) {
            for (let j = 0; j < 9; j++) {
                this.board[i][j] = Math.floor(Math.random() * 9) + 1;
            }
        }
        fillBoard("board", this.board);
    }

    printBoard() {
        console.log(this.board.map(r => r.join(" ")).join("\n"));
    }
}


function drawBoard(containerId) {
    const container = document.getElementById(containerId);
    container.innerHTML = "";
    const table = document.createElement("table");
    for (let i = 0; i < 9; i++) {
        const row = document.createElement("tr");
        for (let j = 0; j < 9; j++) {
            const cell = document.createElement("td");
            cell.className = "cell";
            cell.setAttribute("data-row", i);
            cell.setAttribute("data-col", j);
            row.appendChild(cell);
        }
        table.appendChild(row);
    }
    container.appendChild(table);
}

function fillBoard(containerId, board) {
    const cells = document.querySelectorAll(`#${containerId} td`);
    for (let i = 0; i < 9; i++) {
        for (let j = 0; j < 9; j++) {
            const index = i * 9 + j;
            cells[index].textContent = board[i][j] === 0 ? "" : board[i][j];
        }
    }
}


function clearHighlights() {
    document.querySelectorAll("td").forEach(td => {
        td.classList.remove("error", "highlight");
    });
}

function highlightErrors(rows, cols, squares) {
    const cells = document.querySelectorAll("td");
    const board = game.board;
    let errorCells = new Set();

    rows.forEach(r => {
        let seen = {};
        for (let j = 0; j < 9; j++) {
            const val = board[r][j];
            if (val !== 0) {
                const index = r * 9 + j;
                if (seen[val] !== undefined) {
                    errorCells.add(index);
                    errorCells.add(seen[val]);
                } else {
                    seen[val] = index;
                }
            }
        }
    });

    cols.forEach(c => {
        let seen = {};
        for (let i = 0; i < 9; i++) {
            const val = board[i][c];
            if (val !== 0) {
                const index = i * 9 + c;
                if (seen[val] !== undefined) {
                    errorCells.add(index);
                    errorCells.add(seen[val]);
                } else {
                    seen[val] = index;
                }
            }
        }
    });

    squares.forEach(([r, c]) => {
        let seen = {};
        for (let i = 0; i < 3; i++) {
            for (let j = 0; j < 3; j++) {
                const val = board[r + i][c + j];
                if (val !== 0) {
                    const index = (r + i) * 9 + (c + j);
                    if (seen[val] !== undefined) {
                        errorCells.add(index);
                        errorCells.add(seen[val]);
                    } else {
                        seen[val] = index;
                    }
                }
            }
        }
    });

    errorCells.forEach(index => cells[index].classList.add("error"));

    setTimeout(() => {
        errorCells.forEach(index => cells[index].classList.remove("error"));
    }, 15000);
}

function enableCellEditing() {
    const boardElem = document.getElementById("board");
    boardElem.addEventListener("click", e => {
        const cell = e.target.closest("td");
        if (!cell) return;

        const row = parseInt(cell.getAttribute("data-row"));
        const col = parseInt(cell.getAttribute("data-col"));

        if (game.fixedCells.has(`${row},${col}`)) {
            alert("Эта клетка зафиксирована — изменить нельзя!");
            return;
        }

        const input = prompt("Введите число от 1 до 9 (или оставьте пустым, чтобы очистить):");
        if (input === null || input.trim() === "") {
            cell.textContent = "";
            game.board[row][col] = 0;
            return;
        }

        const num = parseInt(input);
        if (!Number.isInteger(num) || num < 1 || num > 9) {
            alert("Ошибка: нужно ввести число от 1 до 9!");
            return;
        }

        if (game.isValid(row, col, num)) {
            game.board[row][col] = num;
            cell.textContent = num;
        } else {
            alert("Нельзя поставить сюда это число — нарушает правила судоку!");
        }
    });
}




function highlightCorrect() {
    document.querySelectorAll("td").forEach(td => td.classList.add("highlight"));
}


const game = new Sudoku();
drawBoard("board");
fillBoard("board", game.board);

function clearAllHighlightsBeforeAction() {
    clearHighlights();
}

document.getElementById("generate").addEventListener("click", () => {
    clearAllHighlightsBeforeAction();
    game.generateBoard();
});

document.getElementById("checkError").addEventListener("click", () => {
    clearAllHighlightsBeforeAction();
    game.checkAll();
});

document.getElementById("generateValid").addEventListener("click", () => {
    clearAllHighlightsBeforeAction();
    game.generateSolvedBoard();
});

document.getElementById("generatePart").addEventListener("click", () => {
    clearAllHighlightsBeforeAction();
    game.generatePartialBoard();
});

enableCellEditing();