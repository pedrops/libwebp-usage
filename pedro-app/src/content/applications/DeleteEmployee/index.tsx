import { Box, TextField, Typography, Button } from '@mui/material'
import SetEmployeeMinData from '../../../components/EmployeeMinDataForm'
import ApplicationHeader from '../../../layouts/ApplicationHeader'
import { EmployeeModel } from '../../../models/employeeModel';
import { useState } from 'react'
import useGetEmployeeById from '../../../hooks/useGetEmployeeById';

function AddEmployee() {
  const [ employee, setEmployee ]= useState<EmployeeModel | null>();
  const [ id, setId ] = useState<number>()
  const {getEmployeeById} = useGetEmployeeById();
  const searchEmployee = async (e:React.FormEvent<HTMLFormElement>) => {
    e.preventDefault()
    setEmployee(null)
    if (id){
        const data = await getEmployeeById({id})
        setEmployee(data)
    }
  }
  return (
    <>
    <Typography component='label' variant='h4' fontSize='26px'>Search by id:</Typography>
    <Box component='form' onSubmit={searchEmployee} sx={{mb:4, display:'flex', alignItems:'center'}}>
        <TextField type='text' onChange={(e) => setId(parseInt(e.target.value))} size='small' label='Enployee id'/>
        <Button type='submit' variant='contained'>Search</Button>
    </Box>
    <ApplicationHeader headerText='Delete Employee'/>
    { employee && <SetEmployeeMinData type='delete' employee={employee}/>}
    </>
  )
}

export default AddEmployee




// import React, { useEffect, useState } from 'react'
// import useEmployees from '../../../hooks/useEmployees'
// import EmployeeTable from '../../../components/EmployeesTable'
// import ApplicationHeader from '../../../layouts/ApplicationHeader'
// import { Button, Box } from '@mui/material'
// import useGetEmployees from '../../../hooks/useGetEmployees'

// function DeleteEmployee() {
//   const [ isLoading, setIsLoading ] = useState(false)
//   const { deleteEmployees } = useEmployees()
//   const { employees } = useGetEmployees()
//   const [ deletedList, setDeletedList ] = useState<boolean[]>(new Array(employees.length).fill(false))
//   const [ idsToDelete, setIdsToDelete ] = useState<number[]>([])

//   const handleCheck = (index:number) => {
//     const newDeletedList = [... deletedList]
//     newDeletedList[index] = !newDeletedList[index]
//     setDeletedList(newDeletedList)
//   }
//   const handleDelete = () => {
//     setIsLoading(true)
//     setTimeout(() => {
//       deleteEmployees({idsToDelete})
//       setIsLoading(false)
//     },1500)
//   }
//   useEffect(() => {
//     const newIdsToDelete:number[] = []
//     deletedList.forEach((employee, index) => {
//       if (employee) {
//         newIdsToDelete.push(employees[index].id)
//       }
//     })
//     setIdsToDelete(newIdsToDelete)
//   }, [deletedList])

//   return (
//     <>
//     <ApplicationHeader headerText='Delete employee'/>
//     <Box position='relative'>
//       <Button
//       disabled={deletedList.includes(true) && !isLoading? false : true}
//       variant='contained'
//       onClick={handleDelete}
//       sx={{
//         position:'absolute',
//         right:'25px',
//         top:'-35px'
//       }}>
//         Delete employees
//       </Button>
//     </Box>
//     <EmployeeTable employeeList={employees} action={handleCheck}/>
//     </>
//   )
// }

// export default DeleteEmployee