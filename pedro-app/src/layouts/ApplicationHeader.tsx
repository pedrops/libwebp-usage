import { Typography, Divider } from '@mui/material'

function ApplicationHeader({headerText}:{headerText:string}) {
  return (
    <>
        <Typography variant='h1' sx={{fontSize:'42px', mt:4}}>{headerText}</Typography>
        <Divider sx={{mb:4}}/>
    </>
  )
}

export default ApplicationHeader