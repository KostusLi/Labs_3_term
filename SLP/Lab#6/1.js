//1
let [num] = [1, 2, 3, 4, 5];
console.log(num);

console.log("==============================");


//2
let user = {name: "UVUWEVWEVWE ONYETENYEVWE UGWEMUBWEM OSAS", age: 34};
let admin = {admin: "gay", ...user};
console.log(admin)

console.log("==============================");

//3
let store = {
    state: {
        profilePage: {
            posts: [
                {id: 1, message: 'Hi', likesCount: 12},
                {id: 2, message: 'By', likesCount: 1}
            ],
            newPostText: 'About me',
        },

        dialogsPage: {
            dialogs: [
                {id: 1, name: 'Valera'},
                {id: 1, name: 'Andrey'},
                {id: 1, name: 'Sasha'},
                {id: 1, name: 'Viktor'},
            ],
            messages: [
                {id: 1, message: 'hi'},
                {id: 2, message: 'hi hi'},
                {id: 3, message: 'hi hi hi'},
            ],
        },
        sidebar: [],
    },
}

let {
    state: {
        profilePage: {
            posts, 
            str
        }, 
        dialogsPage: {
            dialogs, 
            messages
        }, 
        sidebar
    }
} = store;

console.log(posts);
for(let a of posts)
{
    console.log(a.likesCount);
}

for(let a of dialogs)
{
    if(a.id%2==0) console.log(a);
}

for(let i=0; i<messages.length; i++)
{
    messages[i].message = 'Hello user';
}
console.log(messages);



//4
let tasks = [
    {id:1, title:"HTML&CSS", isDone: true},
    {id:2, title:"JS", isDone: true},
    {id:3, title:"ReactJS", isDone: false},
    {id:4, title:"Rest API", isDone: false},
    {id:5, title:"GraphQL", isDone: false},
];

tasks = [
    ...tasks,
    {id:6, title:"V/crest/crest", isDone: true},
];

console.log(tasks);


//5
let arr = [1, 2, 3];

function sumValues(x, y, z)
{
    return x+y+z;
}

let res = sumValues(...arr);
console.log(res);