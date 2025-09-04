//#10

function f(i=1, n, k)
{
    return i+n+k;
}

let n=3;
let k=+prompt("Что-то введи");
alert(f(undefined,n, k));