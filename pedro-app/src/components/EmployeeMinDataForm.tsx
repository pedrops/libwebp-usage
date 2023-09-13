import { Box, TextField, Typography, Checkbox, Button } from '@mui/material'
import AddCircleIcon from '@mui/icons-material/AddCircle';
import useSetEmployeeData from '../hooks/useSetEmployeeData';
import { useState, useEffect } from 'react';
import SuccessDialog from './SuccessDialog';
import { EmployeeModel } from '../models/employeeModel';

interface EmployeeMinDataFormProps{
    type:'edit'|'add'|'delete',
    employee?:EmployeeModel
}

function EmployeeMinDataForm({type, employee}:EmployeeMinDataFormProps) {
    const [ isLoading, setIsLoading ] = useState(false)
    const SetData = useSetEmployeeData({employee});
    const [ sent, setSent ]= useState(false);
    useEffect(() => {
        if (employee){
            SetData.setId(employee.id)
            SetData.setFirstName(employee.firstName)
            SetData.setLastName(employee.lastName)
            SetData.setAddress(employee.address)
            SetData.setEmail(employee.email)
            SetData.setPhoneNumber(employee.phoneNumber)
            SetData.setProfile(employee.profile)
            SetData.setHourRate(employee.hourRate)
            SetData.setIsFullTime(employee.isFullTime)
            SetData.setActive(employee.active)
        }
    },[])

  return (
    <>
    <Box
    component='form'
    onSubmit={(e) => SetData.Submit({e, type, setIsLoading, setSent})}
    sx={{
        width:'100%',
        height:'100%',
        display:'grid',
        gridTemplateColumns:'1fr 1fr',
        position:'relative'
    }}>
        <div>
            <Typography sx={{maxWidth:'400px', fontSize:'26px'}} variant='h4'>First name:</Typography>
            <TextField sx={{maxWidth:'400px'}} disabled={type
             === 'delete'} defaultValue={employee?.firstName} onChange={(e) => SetData.setFirstName(e.target.value)} required label={''} placeholder={''}/>
        </div>
        <div>
            <Typography sx={{maxWidth:'400px', fontSize:'26px'}} variant='h4'>Last name:</Typography>
            <TextField sx={{maxWidth:'400px'}} disabled={type
             === 'delete'} defaultValue={employee?.lastName} onChange={(e) => SetData.setFirstName(e.target.value)} required label={''} placeholder={''}/>
        </div>
        <div>
            <Typography sx={{maxWidth:'400px', fontSize:'26px'}} variant='h4'>Address:</Typography>
            <TextField sx={{maxWidth:'400px'}} disabled={type
             === 'delete'} defaultValue={employee?.address} onChange={(e) => SetData.setFirstName(e.target.value)} required label={''} placeholder={''}/>
        </div>
        <div>
            <Typography sx={{maxWidth:'400px', fontSize:'26px'}} variant='h4'>Email:</Typography>
            <TextField sx={{maxWidth:'400px'}} disabled={type
             === 'delete'} defaultValue={employee?.email} onChange={(e) => SetData.setFirstName(e.target.value)} required label={''} placeholder={''}/>
        </div>
        <div>
            <Typography sx={{maxWidth:'400px', fontSize:'26px'}} variant='h4'>Phone number:</Typography>
            <TextField sx={{maxWidth:'400px'}} disabled={type
             === 'delete'} defaultValue={employee?.phoneNumber} onChange={(e) => SetData.setFirstName(e.target.value)} required label={''} placeholder={''}/>
        </div>
        <div>
            <Typography sx={{maxWidth:'400px', fontSize:'26px'}} variant='h4'>Profile:</Typography>
            <TextField sx={{maxWidth:'400px'}} disabled={type
             === 'delete'} defaultValue={employee?.profile} onChange={(e) => SetData.setFirstName(e.target.value)} required label={''} placeholder={''}/>
        </div>
        <div>
            <Typography sx={{maxWidth:'400px'}} variant='h4'>Hours rate:</Typography>
            <TextField sx={{maxWidth:'400px'}} disabled={type
             === 'delete'} defaultValue={employee?.hourRate} onChange={(e) => SetData.setHourRate(parseInt(e.target.value))} key={'Hour rates'} required label={'hour rates´'} placeholder={'my hour rate'}/>
        </div>
        <Box>
            <div>
                <Typography sx={{maxWidth:'400px'}} variant='h4'>Is full time?</Typography>
                <Checkbox defaultChecked={employee?.isFullTime} disabled={type
                 === 'delete'} onChange={(e) => SetData.setIsFullTime(e.target.checked)}/>
            </div>
            <div>
                <Typography sx={{maxWidth:'400px'}} variant='h4'>Is active</Typography>
                <Checkbox defaultChecked={employee?.active} disabled={type
                 === 'delete'} onChange={(e) => SetData.setActive(e.target.checked)}/>
            </div>
            <Button
            disabled = {isLoading}
            type='submit'
            sx={{mt:4}}
            variant='contained'
            endIcon={<AddCircleIcon/>}>
                Done
            </Button>
        </Box>
        {sent && <SuccessDialog/>}
    </Box>
    </>
  );
}

export default EmployeeMinDataForm