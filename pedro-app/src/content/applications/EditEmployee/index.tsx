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
        <Button variant='contained' type='submit'>Search</Button>
    </Box>
    <ApplicationHeader headerText='Edit Employee'/>
    { employee && <SetEmployeeMinData type='edit' employee={employee}/>}
    </>
  )
}

export default AddEmployee