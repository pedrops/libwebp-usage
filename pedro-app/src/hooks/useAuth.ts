import { useNavigate } from "react-router-dom"
import { UserSessionContext } from "../contexts/authContext"
import { useContext } from "react"
import bcrypt from 'bcryptjs';


const API = "https://localhost:7224/api/User/ValidateSession?"

type LoginData = {
    email:string,
    password:string
}

type RegisterData = {
    name:string,
    last_name:string,
    email:string,
    range?:string
}


const adminCredentials = {
    email:'umi_boicochea@email.com',
    password:'123456'
}

function useAuth() {
    const navigate = useNavigate()
    const {setIsLogged} = useContext(UserSessionContext)
    async function Login (loginData:LoginData) {
        const res = await fetch(API+'username='+loginData.email+'&password='+loginData.password)
        const data = await res.json()
        if(data === true){
            setIsLogged(true)
            navigate('/admin')
        }
    }
    function LogOut () {
        setIsLogged(false)
    }

    return {Login, LogOut}
}

export default useAuth