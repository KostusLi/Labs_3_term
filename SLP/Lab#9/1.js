//1
let square1 = {
    square: 50,
    color: "yellow"
};
let square2 = {};
square2.__proto__ = square1;
square2.square = 12;
console.log(square2);


let circle1 = {
    square: 50,
    color: "white"
};
let circle2 = {};
circle2.__proto__ = circle1;
circle2.color = "green";
console.log(circle2);

let triangle1 = {
    numOfLine: 1,
    square: 50
};
let triangle2 = {};
triangle2.__proto__ = triangle1;
triangle2.numOfLine = 3;
console.log(triangle2);

console.log(Object.keys(circle2));

console.log(Object.getPrototypeOf(triangle2));

console.log(square2.hasOwnProperty("square"));

console.log("=====================================");


//2

class Human {
    constructor(firstName, lastName, addres, birthYear) {
        this.firstName = firstName;
        this.lastName = lastName; 
        this._addres = addres;
        this.birthYear = birthYear;
    }

    get age() {
        let currentYear = new Date().getFullYear();
        return currentYear-this.birthYear;
    }

    get addres() {
        return this._addres;
    }

    set age(value) {
        let currentYear = new Date().getFullYear();
        this.birthYear = currentYear - value;
    }

    set addres(value) {
        this._addres = value;
    }
}

let hum = new Human("Gay", "Bro", "Minsk", 2007);
console.log(hum);
console.log(hum.age);


class Student extends Human{
    constructor(firtstName, lastName, addres, birthYear, faculty, cours, group, numOfDoc)
    {
        super(firtstName, lastName, addres, birthYear);
        this.faculty = faculty;
        this._cours = cours;
        this._group = group;
        this.numOfDoc = numOfDoc;
    }

    set cours(value)
    {
        this._cours = value;
    }

    set group(value)
    {
        this._group = value;
    }

    getFullName()
    {
        return `${this.firstName} ${this.lastName}`;
    }
}

class Faculty{
    constructor(name) {
        this.name = name;          
        this.numGroups = 0;       
        this.numStudents = 0;      
        this.students = [];
    }

    addStudent(student) {
        if (student instanceof Student && student.faculty === this.name) {
            this.students.push(student);
            this.numStudents++;
            let uniqueGroups = new Set(this.students.map(s => s.group));
            this.numGroups = uniqueGroups.size;
        } else {
            console.log("Ошибка: студент не относится к этому факультету!");
        }
    }


    changeGroups(value) {
        this.numGroups = value;
    }

    changeStudents(value) {
        this.numStudents = value;
    }

    getDev() {
        let devStudents = this.students.filter(st => st.numOfDoc[1]=='3');
        console.log(`Студенты специальности ДЭВИ на факультете ${this.name}:`);
        devStudents.forEach(st => console.log(st.getFullName(), "-", st.numOfDoc));
        return devStudents;
    }

    getGroupe(group) {
        let groupStudents = this.students.filter(st => st.group === group);
        console.log(`Студенты группы ${group}:`);
        groupStudents.forEach(st => console.log(st.getFullName()));
    }
}


let facultyFIT = new Faculty("ФИТ");

let s1 = new Student("Бип", "Боп", "Минск", 2005, "ФИТ", 2, 9, "71201300");
let s2 = new Student("Элвин", "Йорк", "Брест", 2004, "ФИТ", 3, 6, "73201300");
let s3 = new Student("Арнольф", "Шмитлер", "Минск", 2006, "ФИТ", 1, 5, "73201300");

facultyFIT.addStudent(s1);
facultyFIT.addStudent(s2);
facultyFIT.addStudent(s3);

console.log("Количество студентов:", facultyFIT.numStudents);
console.log("Количество групп:", facultyFIT.numGroups);

facultyFIT.getDev();

facultyFIT.getGroupe(9);