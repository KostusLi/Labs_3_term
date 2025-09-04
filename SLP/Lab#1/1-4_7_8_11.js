let a=5;
let name = "Name";
let i=0;
let double = 0.23;
let result = 1/0;
let answer = true;
let no = null;

//#1
console.log(typeof a);
console.log(typeof name);
console.log(typeof i);
console.log(typeof double);
console.log(typeof result);
console.log(typeof answer);
console.log(typeof no);

console.log("===========================");

//#2
console.log(Math.floor((45/5)*(21/5)));


console.log("===========================");

//#3
let i1 = 2;
let a1 = ++i1;
let b1 = i1++;

if(a1==b1){
    console.log("a равно b");
}
else{
    console.log("a не равно b");
}

console.log("===========================");

//#4
console.log("Котик" == "котик" ? "Равны" : "Не равны");
console.log("Котик" == "китик" ? "Равны" : "Не равны");
console.log("Кот" == "Котик" ? "Равны" : "Не равны");
console.log("Привет" == "Пока" ? "Равны" : "Не равны");
console.log(73 == "53" ? "Равны" : "Не равны");
console.log(false == 0 ? "Равны" : "Не равны");
console.log(54 == true ? "Равны" : "Не равны");
console.log(123 == false ? "Равны" : "Не равны");
console.log(true == "3" ? "Равны" : "Не равны");
console.log(3 == "5мм" ? "Равны" : "Не равны");
console.log(8 == "-2" ? "Равны" : "Не равны");
console.log(34 == "34" ? "Равны" : "Не равны");
console.log(null == undefined ? "Равны" : "Не равны");

console.log("===========================");

//#7
console.log(true+true);
console.log(0+"5");
console.log(5+"мм");
console.log(8/Infinity);
console.log(9*"\n9");
console.log(null-1);
console.log(+"5"+2);
console.log("5px"-3);
console.log(true-3);
console.log(7||0);

console.log("===========================");

//#8
for(let i=1; i<11; i++)
{
    if(i%2==0)
    {
        let m=i
        console.log(m+=2);
    }else{
        console.log(i+"мм");
    }
}

console.log("===========================");


//#11
function params1(a, b)
{
    return (a===b) ? 4*a : a*b;
}

const params2 = function(a, b)
{
    return (a===b) ? 4*a: a*b;
}

const params3 = (a, b)=>{
    return (a===b) ? 4*a: a*b;
}

console.log(params1(5, 5));
console.log(params1(5, 7));

console.log(params2(5, 5));
console.log(params2(5, 7));

console.log(params3(5, 5));
console.log(params3(5, 7));