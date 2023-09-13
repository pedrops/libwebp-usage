import { ReactNode, createContext, useEffect, useState } from "react";
import { EmployeeModel } from "../models/employeeModel";
import React from "react";
import { Navigate, useNavigate } from "react-router-dom";

//define Context Type
export type SessionType = {
    user:EmployeeModel | null,
    token:string | null
}
export interface UserContextInterface {
    isLogged:boolean,
    setIsLogged:React.Dispatch<React.SetStateAction<boolean>>
}
const defaultUserContext = {
    isLogged:false,
    setIsLogged:(value:boolean) => {},
} as UserContextInterface

//create context
export const UserSessionContext = createContext(defaultUserContext)

//provide 
export function UserContextProvider ({children}:{children:ReactNode}) {
    const [ userSession, setUserSession ] = useState<SessionType>(
        {user:null,token:null}
    )
    const navigate = useNavigate() 
    const [ isLogged, setIsLogged ] = useState(false)
    useEffect(() => {
        if(isLogged){
            navigate("/admin")
        }
        },[isLogged])
    return (
    <UserSessionContext.Provider value={{isLogged, setIsLogged}}>
        {children}
    </UserSessionContext.Provider>
    )
}