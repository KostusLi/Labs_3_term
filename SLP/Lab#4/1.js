//1
let arr = ["афроамериканец", "кастрюля", "кофе", "мороженое", "печенье"];
let set = new Set(arr);
addProduct(set, "детектор");
addProduct(set, "душа");
console.log(set);
deleteProduct(set, "кастрюля");
hasProduct(set, "афроамериканец");
console.log("Кол-во элементов: " + getSize(set));
set.clear();


function getSize(set)
{
    return set.size;
}

function addProduct(set, product)
{
    set.add(product);
    console.log("Товар добавлен")
}

function deleteProduct(set, product)
{
    if(set.delete(product)){
    console.log("Продукт удален");}
    else{
        console.log("Такого товара нет");
    }
}

function hasProduct(set, product)
{
    if(set.has(product))
    {
        console.log("Товар удален");
    }
    else{
        console.log("Такого товара нет");
    }
    
}


console.log("================================")



//2
let set1 = new Set();
addInfo(set1, 4, 9, "Хаткевич Константин Владимирович");
addInfo(set1, 6, 10, "ПрофессорГлезов Виталий Юрьевич");
addInfo(set1, 2, 9, "Белодед Павел Вячеславович");
addInfo(set1, 90, 10, "Макаревич Кирилл Вадимович");
addInfo(set1, 34, 9, "Белодед Павел Вячеславович");
addInfo(set1, 56, 7, "Максим Киселев Незнаюотчество");
console.log(set1);
deleteInfo(set1, 6);
console.log(set1);
filtrOfGroup(set1, 9);
console.log(sortOfNumber(set1));


function addInfo(set1, number, group, fio)
{
    set1.add({number: number, group: group, fio: fio});
}

function deleteInfo(set1, number)
{
    set1.forEach(x=>x.number===number ? set1.delete(x) : x);
}

function filtrOfGroup(set1, group)
{
    set1.forEach(x=>{if(x.group===group) console.log(x)});
}

function sortOfNumber(set1)
{
    return [...set1].sort((x, y)=>x.number-y.number);
}


console.log("================================")


//3
let map = new Map();
addInfoInMap(map, 1, "Афроамериканец", 5, 1);
addInfoInMap(map, 2, "Паста", 7, 54);
addInfoInMap(map, 3, "Печенье", 12, 43);
addInfoInMap(map, 4, "Печенье", 56, 4);
addInfoInMap(map, 5, "Кастрюля", 27, 14);
delById(map, 2);
console.log(map);
delByName(map, "Печенье");
console.log(map);
changeCount(map, 1, 45);
changeCount(map, 2, 40);
changeCost(map, 5, 89);
addInfoInMap(map, 2, "Паста", 7, 54);
addInfoInMap(map, 3, "Печенье", 12, 43);
addInfoInMap(map, 4, "Печенье", 56, 4);
console.log(sumOfproduct(map));
console.log(countPosition(map));



function addInfoInMap(map, id, name, count, cost)
{
    map.set(id, {name:name, count:count, cost:cost});
}

function delById(map, id)
{
    if(map.delete(id))
    {
        console.log("Элемент удален");
    }else{
        console.log("Элемента нету");
    }
}

function delByName(map, name)
{
    map.forEach((value, key)=>{
        if(value.name===name) 
        map.delete(key);
    });
}

function changeCount(map, id, newCount)
{
    if(map.has(id))
    {
        let temp = map.get(id);
        temp.count = newCount;
        map.set(id, temp);
    }else
    {
        console.log("Нет такого товара!")
    }
}

function changeCost(map, id, newCost)
{
    if(map.has(id))
    {
        let temp = map.get(id);
        temp.cost = newCost;
        map.set(id, temp);
    }else
    {
        console.log("Нет такого товара!")
    }
}

function sumOfproduct(map)
{
    let sum=0;
    map.forEach((value)=>{sum+=value.count*value.cost})
    return sum;
}

function countPosition(map)
{
    return map.size;
}

console.log("================================")

//4
let weakMap = new WeakMap();

let obj1 = {name: "Bond"};
let obj2 = {name: "Maria"};
let obj3 = {name: "James"};

addCache(weakMap, obj1);
addCache(weakMap, obj2);
addCache(weakMap, obj1);
addCache(weakMap, obj3);
console.log(weakMap.has(obj1));
obj1 = null;
console.log(weakMap.has(obj1));


function addCache(weakMap, id)
{
    if(weakMap.has(id))
    {
        console.log("Такое значение уже есть в WeakMap: " + weakMap.get(id))
        return weakMap.get(id);
    }
    else{
        let result=0;
        let str = id.name;
        for(let i=0; i<str.length; i++)
        {
            result+=23*str.charCodeAt(i)/16;
        }
        weakMap.set(id, result);
    }
}
