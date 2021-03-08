export default class Note {
    constructor(){
        this.editMode = false;
    }
    noteId?: number;
    noteText?: string;
    noteDate?: Date;
    editMode?: boolean;
}
