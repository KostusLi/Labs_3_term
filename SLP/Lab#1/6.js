//#6
let russian = confirm("Сдал ли студент русский?");
let math = confirm("Сдал ли студент математику?");
let english = confirm("Сдал ли студент английский?");



if(russian && math && english)
{
    alert("Студента переводят на следующий курс")
}
else if(!russian && !math && !english)
{
    alert("Отчислен");
}
else{
    alert("На пересдачу");
}