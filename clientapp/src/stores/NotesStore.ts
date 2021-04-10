import Note from '../models/Note';
import {  action, computed, makeAutoObservable,  runInAction } from "mobx";
import NotesApi from '../api/NotesApi'


export class NotesStore
{
    notes?:Note[];
    constructor(){
        makeAutoObservable(this);
      //  this.initNotes();
    }

    async initNotes()
    {
        const notesData = await NotesApi.list();
        runInAction(()=>{
            this.notes = notesData;
        });
        // NotesApi.list().then((notes) => {            
        //    this.notes = notes;
        // });    
        //.finally(()=> { setIsLoading(false); })
    }

  @action getAllNotes(){
        return this.notes;
    }

    @action async addNote(noteText:string)
    {
        const note = { noteText, noteDate: new Date(), editMode: false}
        await NotesApi.create(note);
        await this.initNotes();
    }

    @action async deleteNote(id:number){
        if (!window.confirm('Delete?'))
                return;

        await NotesApi.delete(id);
        await this.initNotes();
    }

    @action async updateNote(note:Note){
        await NotesApi.update(note);
        await this.initNotes();
    }

    @computed notesCount(){
        return this.notes?.length;
    }
}

export default NotesStore;
/* const NoteStoreContext = createContext<NotesStore|null>(null);
export default NoteStoreContext; */