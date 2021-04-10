import React, { useContext, useState} from "react"
import _ from 'lodash';
import { observer } from "mobx-react-lite";
import { Button, Card, Spinner } from 'react-bootstrap';
import {RootStoreContext} from "../../stores/RootStore";
import Note from "../../models/Note";
import { AuthenticationContext } from "../../stores/UserAuthStore";
import Loading from "../common/Loading";

const NotesList = observer( () => {

    const rootStore = useContext(RootStoreContext);   
    const noteStore = rootStore.notesStore;
    const [editNoteText, setEditdNoteText] = useState('' as string);
    const authContext = useContext(AuthenticationContext);

    if (!authContext.isUserAuthenticated)
    {
        return <Loading/>;
    }

    const notes = noteStore?.getAllNotes();

    const findSelectedNote = (id:Number):Note => {
        const notes = noteStore?.getAllNotes();
        const item = _.find(notes, (n:Note)=> n.noteId===id) as Note;
        return item;
    }

    const handleDelete = async (id: number) => {
        await noteStore?.deleteNote(id!);
    };

    const toggleEditModeById = (id: number|undefined) => {
        const selectedNote = findSelectedNote(id!);
        toggleEditMode(selectedNote);
    };

    const toggleEditMode = (selectedNote:Note) => {        
        selectedNote.editMode = !selectedNote.editMode;
    };

    const handleEditMode = (id: number|undefined): void => {
          
            const selectedNote = findSelectedNote(id!);
            setEditdNoteText(selectedNote.noteText!);
            toggleEditMode(selectedNote);
    };

    const handleChange = (event: React.ChangeEvent<HTMLTextAreaElement>) => {        
        setEditdNoteText(event.currentTarget.value);
    };

    const handleUpdate = (id: number|undefined) => {
        const selectedNote = findSelectedNote(id!);
        const noteUpdate = {noteId: id, noteText: editNoteText, noteDate: selectedNote.noteDate};
        noteStore?.updateNote(noteUpdate);
        toggleEditMode(selectedNote);        
    };

    return (<div>        
        { notes==null ? (<Spinner animation="border" role="status">
  <span className="sr-only">Loading...</span>
</Spinner>) : <></> }

            {notes?.map(n => 
                (<Card key={n.noteId}>
                <Card.Header>{n.noteDate}</Card.Header>
                <Card.Body>                    
                    <Card.Text>

                    {n.editMode ? <textarea className="form-control" 
                         onChange={handleChange}
                        value={editNoteText} ></textarea> : <span> {n.noteText}</span>}
                    
                    </Card.Text>
                  
                  {n.editMode ? <div>
                    <Button className="btn btn-sm btn-primary"
                    onClick={(e) => handleUpdate(n.noteId)}
                    variant="primary">&nbsp;Update&nbsp;</Button>&nbsp;

                    <Button className="btn btn-sm btn-secondary"
                    onClick={(e) => {toggleEditModeById(n.noteId)}}
                    variant="default">&nbsp;Cancel&nbsp;</Button>
                  </div> 
                  : 
                  <div><Button 
                    className="btm btn-sm btn-danger" 
                    onClick={(e) => { handleDelete(n.noteId!); }}
                    variant="danger">Delete</Button>&nbsp;
                    <Button className="btn btn-sm btn-primary"
                    onClick={(e) => {handleEditMode(n.noteId)}}
                    variant="primary">&nbsp;Edit&nbsp;</Button></div>}
                    
            </Card.Body>
            </Card>)
            )}
        
    </div>);
} );

export default NotesList;