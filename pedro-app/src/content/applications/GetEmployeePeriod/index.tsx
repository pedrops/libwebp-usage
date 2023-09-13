import { useState } from 'react'
import ApplicationHeader from '../../../layouts/ApplicationHeader'
import { Box, Typography, TextField , Button} from '@mui/material'
import CalendarMonthIcon from '@mui/icons-material/CalendarMonth';
import useEmployees from '../../../hooks/useEmployees';
import { WeekPeriodModel } from '../../../models/weekPeriodModel';
import EmployeePeriod from '../../../components/EmployeePeriod';
import PeriodTable from '../../../components/PeriodTable';
import useGetPeriod from '../../../hooks/useGetPeriod';

function GetEmployeePeriod() {
  const { getPeriod } = useGetPeriod()
  const [ period, setPeriod ] = useState<WeekPeriodModel>()
  const [ employeeId, setEmployeeId ] = useState<number>();
  const [ weekPeriodId, setWeekPeriodId ] = useState<string>();
  const handleSetId = (e:React.ChangeEvent<HTMLInputElement>) => {
      setEmployeeId(parseInt(e.target.value))
  }
  const handleSetPeriod = (e:React.ChangeEvent<HTMLInputElement>) => {
    setWeekPeriodId(e.target.value)
  }
  const handleClick = () => {
    if ( employeeId && weekPeriodId){
      setPeriod(getPeriod({employeeId, weekPeriodId}))
    }
  }
  return (
    <>
    <ApplicationHeader headerText='Get employee period'/>
    <Typography sx={{mb:2}} variant='h4' fontSize='26px'>Search by id:</Typography>
    <Box sx={{mb:4, display:'flex', alignItems:'center', justifyContent:'space-around', width:'70%'}}>
        <Box sx={{display:'flex', alignItems:'center'}}>
          <TextField type='text' onChange={handleSetId} size='small' label='Enployee id'/>
        </Box>
        <Box sx={{display:'flex', alignItems:'center'}}>
          <TextField type='text' onChange={handleSetPeriod} size='small' label='Enployee Period'/>
          <Button sx={{ml:4}} onClick={handleClick} disabled={employeeId === undefined || weekPeriodId === undefined} variant='contained' endIcon={<CalendarMonthIcon/>}>Get Period</Button>
        </Box>
    </Box>
    <Box sx={{width:'100%', height:'100%', display:'flex', justifyContent:'center', alignItems:'center'}}>
      { period && <PeriodTable period={period}/>}
    </Box>
    </>
  )
}

export default GetEmployeePeriod