import React from 'react'
import { useState } from 'react'
import useAddEmployee from './useAddEmployee'
import { EmployeeMinimunData, EmployeeModel } from '../models/employeeModel'

const API = 'https://localhost:7224/api/Employee/GetEmployeeById?Id='

interface SetDataProps {
  employee?: EmployeeMinimunData
}

function useSetEmployeeData({employee}:SetDataProps) {
    const [ id, setId ] = useState<number>(0)
    const [ firstName, setFirstName ] = useState<string>('')
    const [ lastName, setLastName ] = useState<string>('')
    const [ address, setAddress ] = useState<string>('')
    const [ email, setEmail ] = useState<string>('')
    const [ phoneNumber, setPhoneNumber ] = useState<string>('')
    const [ hourRate, setHourRate ] = useState<number>(0)
    const [ profile, setProfile ] = useState<string>('')
    const [ isFullTime, setIsFullTime ] = useState(false)
    const {addEmployee, editEmployee, deleteEmployee} = useAddEmployee()
    const [ active, setActive ] = useState(false)

    const handleSetId = (e:React.ChangeEvent<HTMLInputElement>) => {
      setId(parseInt(e.target.value))
      console.log(e.target.value)
  }

    const Submit = ( {e, type, setIsLoading, setSent}:{e:React.FormEvent<HTMLFormElement>, type:'edit'|'add'|'delete', setIsLoading:React.Dispatch<React.SetStateAction<boolean>>, setSent:React.Dispatch<React.SetStateAction<boolean>>}) => {
        e.preventDefault()
        setIsLoading(true)
        setSent(true)
        const employeeData = {
          id,
          firstName,
          lastName,
          address,
          email,
          phoneNumber,
          hourRate,
          profile,
          isFullTime,
          active
        }
        type === 'add'? 
        addEmployee(employeeData)
         :  
          type === 'edit'?
            editEmployee(employeeData)
            :
            deleteEmployee(employeeData.id)
        setIsLoading(false)
    }

  return {
    Submit,
    handleSetId,
    id,
    setFirstName,
    setLastName,
    setAddress,
    setEmail,
    setPhoneNumber,
    setHourRate,
    setProfile,
    setIsFullTime,
    setActive,
    setId
  }
}

export default useSetEmployeeData