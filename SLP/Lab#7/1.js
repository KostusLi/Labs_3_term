//1
let person = {
    name: "Uga-buga",
    age: 20,

    greet()
    {
        console.log("Hi, " + this.name);
    },   

    ageAfteryears(year)
    {
        return year+this.age;
    }
}

person.greet();
console.log(person.ageAfteryears(12));

console.log("===========================");


//2
let car = {
    model: "perche-metro",
    year: 2033,

    getInfo()
    {
        console.log("Модель тачилы: " + this.model + ", а год выпуска: " + this.year);
    }
}


console.log("===========================");

//3
function Book(title, author)
{
    this.title = title;
    this.author = author;
}

Book.prototype.getTitle = function(){
    return this.title;
}

Book.prototype.getAuthor = function(){
    return this.author;
}

let book = new Book("Айвенго", "Вальтер Скотт");

console.log(book.getTitle());
console.log(book.getAuthor());


console.log("===========================");


//4
let team = {
    players: ["Чо-Ко-Пай", "Пан-Ки-Хой", "Ким-Чен-Ын", "От-Че-Наш", "Ин-Су-Лин"],

    printInfo()
    {
        console.log("DreamTeam:")
        this.players.forEach(element => {
            console.log(element);
        });
    }
}

team.printInfo();

console.log("===========================");

//5
const counter = (function() {
    let count=0;

return {
    increment: function()
    {
        count++;
        return count;
    },

    decrement: function()
    {
        count--;
        return count;
    },

    getCount: function()
    {
        return count;
    }
};
})();

console.log(counter.increment());
console.log(counter.increment());
console.log(counter.decrement());
console.log(counter.getCount());


console.log("===========================");


//6
let item = {
    price: 2000
};

Object.defineProperty(item, 'price', {
    writable: false,
    configurable: false
})



//7
let circle = {
    _radius: 13,
}

Object.defineProperty(circle, 'radius', {
    get: function()
    {
        return this._radius;
    },

    set: function(value)
    {
        this._radius = value;
    }
});

Object.defineProperty(circle, 'square', {
    get: function()
    {
        return Math.PI*this._radius*this._radius;
    }
});

console.log(circle.square);

console.log("===========================");

//8
let car1 = {
    model: "metro",
    year: 2033,
    make: "perche"
}

Object.freeze(car1);


//9
let num = [1, 2, 3];

Object.defineProperty(num, 'sum', {
    get: function()
    {
        return this.reduce((total, current)=>total+current, 0);
    }
});

console.log(num.sum);

console.log("===========================");

//10
let rectangle = {
    _width: 12,
    _height: 34 
};

Object.defineProperties(rectangle, {
    square:{
        get: function()
        {
            return this._width*this._height;
        }
    },

    width:{
        get: function()
        {
            return this._width;
        },

        set: function(value)
        {
            this._width = value;
        }
    },

    height:{
        get: function(){
            return this._height;
        },

        set: function(value)
        {
            this._height = value;
        }
    }
});

console.log(rectangle.square);


console.log("===========================");


//11
let user = {
    firstName: "Oleg",
    lastName: "Mongol"
};

Object.defineProperty(user, 'fullName', {
    get ()
    {
        return `${this.firstName} ${this.lastName}`;
    },

    set (value)
    {
        [this.firstName, this.lastName] = value.split(" ");
    }
});

console.log(user.fullName);
user.fullName = "Elvin York";
console.log(user.fullName);