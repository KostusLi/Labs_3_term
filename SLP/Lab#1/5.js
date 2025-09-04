//#5
let n = "Владимир";
let n1 = "Владимир Вячеславович";
let n2 = "Смелов Владимир Вячеславович";

let n3 = prompt("Введите преподавателя");

if(n.toUpperCase()==n3.toUpperCase() || n1.toUpperCase()==n3.toUpperCase() || n2.toUpperCase()==n3.toUpperCase())
{
    alert("Данные верные");
} else{
    alert("Отчислен!");
}