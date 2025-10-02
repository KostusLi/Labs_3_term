let  user = {
    name: 'Masha',
    age: 21
};


let numbers = [1, 2, 3];


let user1 = {
    name: 'Masha',
    age: 23,
    location: {
        city: 'Minsk',
        country: 'Belarus'
    }
};


let user2 = {
    name: 'Masha',
    age: 28,
    skills: ["HTML", "CSS", "JavaScript", "React"]
};


const array = [
    {id: 1, name: 'Vasya', group: 10}, 
    {id: 2, name: 'Ivan', group: 11},
    {id: 3, name: 'Masha', group: 12},
    {id: 4, name: 'Petya', group: 10},
    {id: 5, name: 'Kira', group: 11},
]


let user4 = {
    name: 'Masha',
    age: 19,
    studies: {
        university: 'BSTU',
        speciality: 'designer',
        year: 2020,
        exams: {
            maths: true,
            programming: false
        }
    }
};


let user5 = {
    name: 'Masha',
    age: 22,
    studies: {
        university: 'BSTU',
        speciality: 'designer',
        year: 2020,
        department: {
            faculty: 'FIT',
            group: 10,
        },
        exams: [
            { maths: true, mark: 8},
            { programming: true, mark: 4},
        ]
    }
};


let user6 = {
    name: 'Masha',
    age: 21,
    studies: {
        university: 'BSTU',
        speciality: 'designer',
        year: 2020,
        department: {
            faculty: 'FIT',
            group: 10,
        },
        exams: [
            { 
		maths: true,
		mark: 8,
		professor: {
		    name: 'Ivan Ivanov ',
		    degree: 'PhD'
		}
	     },
            { 
		programming: true,
		mark: 10,
		professor: {
		    name: 'Petr Petrov',
		    degree: 'PhD'
		}
	     },
        ]
    }
};
 
let user7 = {
    name: 'Masha',
    age: 20,
    studies: {
        university: 'BSTU',
        speciality: 'designer',
        year: 2020,

        department: {
            faculty: 'FIT',
            group: 10,
        },

        exams: [
            { 
		maths: true,
		mark: 8,
		professor: {
		    name: 'Ivan Petrov',
		    degree: 'PhD',
		    articles: [
                        {title: "About HTML", pagesNumber: 3},
                        {title: "About CSS", pagesNumber: 5},
                        {title: "About JavaScript", pagesNumber: 1},
                    ]
		}
	     },
            { 
		programming: true,
		mark: 10,
		professor: {
		    name: 'Petr Ivanov',
		    degree: 'PhD',
		    articles: [
                        {title: "About HTML", pagesNumber: 3},
                        {title: "About CSS", pagesNumber: 5},
                        {title: "About JavaScript", pagesNumber: 1},
                    ]
		}
	     },
        ]
    }
};


let store = {
    state: {
        profilePage: {
            posts: [
                {id: 1, message: 'Hi', likesCount: 12},
                {id: 2, message: 'By', likesCount: 1},
            ],
            newPostText: 'About me',
        },

        dialogsPage: {
            dialogs: [
                {id: 1, name: 'Valera'},
                {id: 2, name: 'Andrey'},
                {id: 3, name: 'Sasha'},
                {id: 4, name: 'Viktor'},
            ],
            messages: [
                {id: 1, name: 'hi'},
                {id: 2, name: 'hi hi'},
                {id: 3, name: 'hi hi hi'},
            ],
        },
        sidebar: [],
    }
}


let temp = structuredClone(user7);
console.log(temp);

let temp1 = deepClone(user);
console.log(temp1);

let temp2 = deepClone(numbers);
console.log(temp2);

let temp3 = deepClone(array);
console.log(temp3)

let temp4 = structuredClone(user1);
console.log(temp4);

let temp5 = structuredClone(user2);
console.log(temp5);

let temp6 = structuredClone(user4);
console.log(temp6);

let temp7 = deepClone(user5);
console.log(temp7);

let temp8 = structuredClone(user6);
console.log(temp8);

let temp9 = deepClone(store);
console.log(temp9);


console.log("=================================");

temp7.studies.department.group = 12;
temp7.studies.exams[1].mark = 10;

console.log(temp7);
console.log(user5);

console.log("=================================");

temp8.studies.exams[0].professor.name = "Ivan Abramov";

console.log(temp8);
console.log(user6);

console.log("=================================");

temp.studies.exams[1].professor.articles[1].pagesNumber = 3;
console.log(temp);
console.log(user7);

temp9.state.profilePage.posts = temp9.state.profilePage.posts.map(p => ({ ...p, message: "Hello" }));

temp9.state.dialogsPage.messages = temp9.state.dialogsPage.messages.map(m => ({ ...m, message: "Hello" }));

console.log(temp9);
console.log(store);

function deepClone(obj) {
  if (Array.isArray(obj)) {
    return [...obj.map(item => deepClone(item))];
  } else if (obj !== null && typeof obj === "object") {
    return {
      ...Object.keys(obj).reduce((acc, key) => {
        acc[key] = deepClone(obj[key]);
        return acc;
      }, {})
    };
  }
  return obj;
}




