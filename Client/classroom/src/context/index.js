import { createContext, useContext, useEffect, useState } from "react";
import React from 'react';
import StorageKeys from 'constants/storage-keys';
const AddContext = createContext();

export function useLocalContext() {
    return useContext(AddContext);
}

export default function ContextProvider({ children }) {
    const [createClassDialog, setCreateClassDialog] = useState(false);
    const [joinClassDialog, setJoinClassDialog] = useState(false);
    const [logged, setLogged] = useState(false);
    const [user, setuser] = useState(null);
    const token = localStorage.getItem(StorageKeys.TOKEN);
    const userlogined =JSON.parse(localStorage.getItem(StorageKeys.USER)) ;
    useEffect(() => {

        setLogged(token);
        setuser(userlogined);

    }, []);
    const value = {
        createClassDialog,
        setCreateClassDialog,
        joinClassDialog,
        setJoinClassDialog,
        logged,
        user
    };

    return <AddContext.Provider value={value}>{children}</AddContext.Provider>;
}
