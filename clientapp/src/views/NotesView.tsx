import React from 'react';
import AddNote from '../components/Notes/AddNote';
import NotesList from '../components/Notes/NotesList';




const NotesView = () => {

    return ( 
        <React.Fragment>
            <AddNote/>
            <NotesList/>
        </React.Fragment>
        );
};

export default NotesView;