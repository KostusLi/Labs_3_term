//1
let arr = [1, [1, 2, [3, 4]], [2, 4]];
let result = arr.reduce((arr, current)=>arr.concat(current), []);
let result2 = result.reduce((arr, current)=>arr.concat(current), []);
console.log(result2);


//2
const arr1 = [20,2,[7,5,3,[100,5, 67],3],56,4];
const sum = arr => arr.reduce((res, el) => {
    return res + (Array.isArray(el) ? sum(el) : el)}, 0);

console.log(sum(arr1));


//3
let arr3 = [
    {name: "Kostay", age: 18, groupId: 9},
    {name: "Vlad", age: 18, groupId: 9 },
    {name: "Masha", age: 17, groupId: 1 }
]

let res = arr3.filter(el=>el.age>17);
console.log(res);


//4
let str = "Hell";
let arr4 = str.split("");
console.log(arr4);

let arr5=[];

for(let i=0; i<arr4.length; i++)
{
    arr4[i] = arr4[i].charCodeAt();
    arr5.push(arr4[i]);
    arr4[i] = arr4[i].toString().replace("7", "1");
}

let total1 = arr5.join('');
let total2 = arr4.join('');

console.log(total1-total2);

console.log(arr4);
console.log(arr5);



//5
const obj1 = {1: "arr",
              2: "bty",
              3: "c"};

const obj2 = {12: "Rjhy", 8: "tjgrfk", 7: "tkjgr" };
const resultObj = Object.assign(obj1, obj2);
console.log(resultObj);


//6
let maxCount = prompt("Введите кол-во этажей");

let num1;
if(maxCount%2==0)
{
    num1 = (maxCount-2)/2;
}else {
    num1 = maxCount-1;
}

for(let i=0; i<maxCount; i++)
{
    let str = "";

    for (let j = 0; j < maxCount - i - 1; j++) {
        str += " ";
    }

    for (let k = 0; k < 2 * i + 1; k++) {
        str += "*";
    }

    console.log(str);
}