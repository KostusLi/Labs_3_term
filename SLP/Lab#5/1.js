//1
/*function makeCounter(){
    let currentCount=1;

    return function(){
        return currentCount++;
    };
}

let counter = makeCounter();

alert(counter());
alert(counter());
alert(counter());

let counter2 = makeCounter();

alert(counter2());*/

//[[Environment]], которое хранит ссылку на лексическое окружение, в котором была создана функция:


//2
function a(a)
{
    return function(b){
        return function(c)
        {
            return a*b*c;   
        }
    }
}

console.log(a(3)(4)(5));
let fixFirstWall = a(6);
console.log(fixFirstWall(4)(10))


console.log("===============================================");


//3

function* move(side, x, y) {
    for (let i = 0; i < 10; i++) {
        if (side === "left") x -= 1;
        if (side === "right") x += 1;
        if (side === "up") y += 1;
        if (side === "down") y -= 1;
        yield {x, y};
    }
}

let x = 0, y = 0;

let it = prompt("Сколько раз будем ходить?", 0);

for (let i = 0; i < it; i++) {
    let side = prompt("Куда идем? (left, right, up, down)", "up");
    let gen = move(side, x, y);
    for (let step of gen) {
        console.log(step);
        x = step.x;
        y = step.y;
    }
}

console.log("===============================================");


//4
var b = 5;
var t= 6;
function f(h)
{
    return h;
}

console.log(f(4));
console.log(b);
console.log(t);


window.f = function()
{
    return "Override";
} 

window.b = 9;
window.t = 10;

console.log(f());
console.log(b);
console.log(t);
