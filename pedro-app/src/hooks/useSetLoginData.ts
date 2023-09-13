import { useState } from "react";
import useAuth from "./useAuth";


function useSetLoginData( {setIsLoading}:{setIsLoading:React.Dispatch<React.SetStateAction<boolean>>} ) {
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const Auth = useAuth()
    const Submit = async (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault()
        setIsLoading(true)
        await Auth.Login({email, password}) //misses an await for when the api is able!!
        setIsLoading(false)
      };
    
    const ChangeEmail = (e:React.ChangeEvent<HTMLInputElement>) => {
      setEmail(e.target.value)
    }
    const ChangePassword = (e:React.ChangeEvent<HTMLInputElement>) => {
      setPassword(e.target.value)
    }

  return { ChangeEmail, ChangePassword, Submit}
}

export default useSetLoginData