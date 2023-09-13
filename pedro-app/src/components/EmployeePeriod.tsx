import { Box, Typography } from '@mui/material'
import { WeekPeriodModel } from '../models/weekPeriodModel'

function EmployeePeriod({period}:{period:WeekPeriodModel}) {
    const periodData = [
        {title:'first name', content:period.firstName},
        {title:'last name', content:period.lastName},
        {title:'first address', content:period.address},
        {title:'first email', content:period.email},
        {title:'first phoneNumber', content:period.phoneNumber},        
        {title:'first profile', content:period.profile},
        {title:'first isFullTime', content:period.isFullTime},
        {title:'first hourRate', content:period.hourRate},
        {title:'first active', content:period.active},
        {title:'first bonus', content:period.bonus},
        {title:'first weekPayment', content:period.weekPayment},
        {title:'first weekTotalPayment', content:period.weekTotalPayment},
        {title:'Worked hours', content:period.workedHours},
        {title:'Inserted date', content:period.insertedDate},
        {title:'Updated Date', content:period.updatedDate},
    ]
  return (
    <Box
    sx={{
        width:'350px',
        height:'350px',
        bgcolor:'#c2c2c2',
        borderRadius:'1.5em',
        textAlign:'left',
        justifyContent:'center',
        boxShadow:'0 0 0 10px #ede7d1'
    }}>
        {periodData.map((data, index) =>
            <>
                <Typography sx={{fontSize:'26px', ml:4}} variant='h3' key={data.title}>{data.title}</Typography>
                <Typography sx={{fontSize:'18px', ml:6}} key={index}>-{data.content}</Typography>
            </>
        )}
        
    </Box>
  )
}

export default EmployeePeriod