import ToDo from '../models/ToDo';
import ToDosApi from '../api/ToDoApi';
import _ from 'lodash';
import {  action, computed, makeAutoObservable,  runInAction } from "mobx";

export class ToDoStore
{
    todos?:ToDo[];
    
    constructor() {
         makeAutoObservable(this);
         this.initToDos();
    }

    async initToDos(){
        const todosData = await ToDosApi.list();
       // console.log(todosData);
        runInAction(()=> {
            this.todos = todosData;
        });
    }

    @action getAllToDos(){
        return this.todos;
    }

    @action async updateToDo(item:ToDo)
    {
            await ToDosApi.update(item);
            await this.initToDos();
    }

    @action async AddToDo(item:ToDo)
    {
        await ToDosApi.create(item);
        await this.initToDos();
    }

    @action async Delete(id:number)
    {
        await ToDosApi.delete(id);
        await this.initToDos();
    }

    @computed totalTodosCount(){
        return this.todos?.length;
    }

    @computed completedTodosCount(){
        const completedTask = _.filter(this.todos, (t) => t.isCompleted);      
        if (!completedTask)
            return 0;

        return completedTask.length;
    }
}

export default ToDoStore;