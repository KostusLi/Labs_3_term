class Task{
    constructor(id, name, completed)
    {
        this.id = id;
        this.name = name;
        if(typeof completed == "boolean")
        {
            this.completed = completed;
        }else{
            this.completed = false;
        }
    }

    changeName(value)
    {
        this.name = value;
    }

    changeEnding(value)
    {
        this.completed = value;
    }
}

class Todolist
{
    constructor(id, name){
        this.id = id;
        this.name = name;
        this.task = [];
    }

    addTask(task)
    {
        this.task.push(task);
    }

    filterTaskIncomplete()
    {
        return this.task.filter(s=>!s.completed);
    }

    filterTaskComplete()
    {
        return this.task.filter(s=>s.completed);
    }
}



let todoList = new Todolist(1, "Мой список дел");

// let p1 = new Task(1, "gray", false);
// let p2 = new Task(2, "girl", true);
// let p3 = new Task(3, "ljlkhm", false);

// todoList.addTask(p1);
// todoList.addTask(p2);
// todoList.addTask(p3);

function displayTasks(tasks = todoList.task) {
    const existingList = document.querySelector('.task-list');
    if (existingList) {
        existingList.remove();
    }

    const taskList = document.createElement('div');
    taskList.className = 'task-list';

    tasks.forEach(task => {
        const taskElement = document.createElement('div');
        taskElement.className = 'task-item';
        taskElement.dataset.id = task.id;
        
        taskElement.style.backgroundColor = task.completed ? '#91ce93ff' : '#fff';

        const checkbox = document.createElement('input');
        checkbox.type = 'checkbox';
        checkbox.checked = task.completed;
        checkbox.style.marginRight = '10px';
        checkbox.style.transform = 'scale(1.5)';
        
        checkbox.addEventListener('change', function() {
            task.changeEnding(this.checked);

            taskElement.style.backgroundColor = this.checked ? '#91ce93ff' : '#fff';

            const taskText = taskElement.querySelector('span');

            if (this.checked) {
                taskText.style.textDecoration = 'line-through';
                taskText.style.color = '#888';
            } else {
                taskText.style.textDecoration = 'none';
                taskText.style.color = '#000000ff';
            }
        });

        const taskText = document.createElement('span');
        taskText.textContent = task.name;
        taskText.style.flex = '1';
        taskText.style.fontSize = '17px';
        taskText.style.textDecoration = task.completed ? 'line-through' : 'none';
        taskText.style.color = task.completed ? '#888' : '#000';

        const deleteButton = document.createElement('button');
        deleteButton.textContent = 'Удалить';
        deleteButton.style.backgroundColor = '#ff4444';
        deleteButton.style.color = 'white';
        deleteButton.style.border = 'none';
        deleteButton.style.borderRadius = '5px';
        deleteButton.style.padding = '13px 10px';
        deleteButton.style.cursor = 'pointer';
        deleteButton.style.fontSize = '17px';

        const changeButton = document.createElement('button');
        changeButton.textContent = 'Редактировать';
        changeButton.style.backgroundColor = '#033ceaff';
        changeButton.style.color = 'white';
        changeButton.style.border = 'none';
        changeButton.style.borderRadius = '5px';
        changeButton.style.padding = '13px 10px';
        changeButton.style.cursor = 'pointer';
        changeButton.style.fontSize = '17px';
        changeButton.style.marginRight = '10px';
        
        deleteButton.addEventListener('click', function() {
            const taskIndex = todoList.task.findIndex(t => t.id === task.id);
            if (taskIndex !== -1) {
                todoList.task.splice(taskIndex, 1);
            }
            taskElement.remove();
        });

        changeButton.addEventListener('click', function() {
            const editInput = document.createElement('input');
            editInput.type = 'text';
            editInput.value = task.name;
            editInput.style.flex = '1';
            editInput.style.marginRight = '10px';
            editInput.style.padding = '5px';
            editInput.style.fontSize = '17px';
            editInput.style.border = '2px solid #033ceaff';
            editInput.style.borderRadius = '5px';
    
            const cancelButton = document.createElement('button');
            cancelButton.textContent = 'Отмена';
            cancelButton.style.backgroundColor = '#ff4444';
            cancelButton.style.color = 'white';
            cancelButton.style.border = 'none';
            cancelButton.style.borderRadius = '5px';
            cancelButton.style.padding = '13px 10px';
            cancelButton.style.cursor = 'pointer';
            cancelButton.style.fontSize = '17px';
            cancelButton.style.marginRight = '10px';
    
            const leftContainer = taskElement.querySelector('div');
            const taskText = leftContainer.querySelector('span');
            leftContainer.replaceChild(editInput, taskText);
    
            changeButton.style.display = 'none';
            taskElement.insertBefore(cancelButton, deleteButton);
    
            editInput.focus();
            editInput.select();
    
            function saveChanges() {
                const newName = editInput.value.trim();
                if (newName !== '') {
                task.changeName(newName);
            
                taskText.textContent = newName;
                leftContainer.replaceChild(taskText, editInput);
            
                changeButton.style.display = 'block';
                cancelButton.remove();
                }
            }
    
            function cancelChanges() {
                leftContainer.replaceChild(taskText, editInput);
        
                changeButton.style.display = 'block';
                cancelButton.remove();
            }
    
            cancelButton.addEventListener('click', cancelChanges);
    
            editInput.addEventListener('keypress', function(e) {
                if (e.key === 'Enter') {
                    saveChanges();
                }
            });
    
            editInput.addEventListener('keydown', function(e) {
                if (e.key === 'Escape') {
                    cancelChanges();
                }
            });
    });


        const leftContainer = document.createElement('div');
        leftContainer.style.display = 'flex';
        leftContainer.style.alignItems = 'center';
        leftContainer.style.flex = '1';
        
        leftContainer.appendChild(checkbox);
        leftContainer.appendChild(taskText);
        taskElement.appendChild(leftContainer);
        taskElement.appendChild(changeButton);
        taskElement.appendChild(deleteButton);
        taskList.appendChild(taskElement);
    });

    document.body.appendChild(taskList);
}

function addNewTask() {
    const input = document.querySelector('.enter');
    const taskName = input.value.trim();
    
    if (taskName === '') {
        alert('Пожалуйста, введите задачу');
        return;
    }

    const newId = todoList.task.length > 0 ? Math.max(...todoList.task.map(t => t.id)) + 1 : 1;
    const newTask = new Task(newId, taskName, false);
    
    todoList.addTask(newTask);
    
    input.value = '';
    
    displayTasks();
}

document.addEventListener('DOMContentLoaded', function() {
    displayTasks();

    const addButton = document.querySelector('.add_task');
    addButton.addEventListener('click', addNewTask);

    const input = document.querySelector('.enter');
    input.addEventListener('keypress', function(e) {
        if (e.key === 'Enter') {
            addNewTask();
        }
    });

    const showAllButton = document.querySelector('.show_all');
    const showCompleteButton = document.querySelector('.show_complete');
    const showIncompleteButton = document.querySelector('.show_incomplete');

    showAllButton.addEventListener('click', function() {
        displayTasks(todoList.task);
    });

    showCompleteButton.addEventListener('click', function() {
        displayTasks(todoList.filterTaskComplete());
    });

    showIncompleteButton.addEventListener('click', function() {
        displayTasks(todoList.filterTaskIncomplete());
    });
});