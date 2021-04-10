import { configure } from "mobx";
import NotesStore from './NotesStore';
import ToDosStore from './ToDoStore';
import { createContext } from "react";

configure({enforceActions: 'always'});

export class RootStore
{
    notesStore: NotesStore;
    todosStore: ToDosStore;
    
    constructor(){
        this.notesStore = new NotesStore();
        this.todosStore = new ToDosStore();
    }

    async Init(){
       await this.notesStore.initNotes();
       await this.todosStore.initToDos()
    }
}

export const RootStoreContext = createContext({} as RootStore);