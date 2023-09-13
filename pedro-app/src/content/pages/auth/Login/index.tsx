import {
    Box,
    Paper,
    Typography,
    TextField,
    IconButton,
    Divider,
    Checkbox,
    Button
} from '@mui/material'
import VisibilityOffIcon from '@mui/icons-material/VisibilityOff';
import VisibilityIcon from '@mui/icons-material/Visibility';
import EastIcon from '@mui/icons-material/East';
import './index.css'
import { Link } from 'react-router-dom'
import useSetLoginData from '../../../../hooks/useSetLoginData';
import { useState } from 'react';


function LoginPage() {
    const [ isLoading, setIsLoading ] = useState(false)
    const Login = useSetLoginData({setIsLoading})
    const [ seePassword, setSeePassword ] = useState(false)
    const handleSeePassword = () => {
        setTimeout(() => {
            setSeePassword(false)
        },500)
        setSeePassword(!seePassword)
    }
  return (
    <Box sx={{positin:'relative',height:'100vh',display:'flex', justifyContent:'center', alignItems:'center'}}>
        <img className='BusinessBrand' src='/assets/Svgs/blueMountain.svg'/>
        <Paper
        component='form'
        onSubmit={(e) => Login.Submit(e)}
        sx={{
            zIndex:1,
            width:'500px',
            height:'600px',
            borderRadius:'1.5em',
            bgcolor:'#f7f7f7',
            display:'flex',
            flexDirection:'column',
            alignItems:'center',
            gap:'25px',
            px:'50px'
        }}
        variant='outlined'>
            <img className='BusinessLogo' src='assets/Svgs/blueMountainLogo.svg'/>
            <Typography sx={{mt:16}} variant='h3' fontSize='36px' >Welcome again!</Typography>
            <Divider sx={{width:'90%'}}/>
            <TextField onChange={Login.ChangeEmail} disabled={isLoading} fullWidth type='email' placeholder='Myemail@email.com' label='Your email'/>
            <Box component='div' sx={{width:'100%',position:'relative',display:'flex', alignItems:'center'}}>
                <TextField onChange={Login.ChangePassword} disabled={isLoading} fullWidth type={seePassword? 'text' : 'password'} label='Your password' sx={{position:'relative'}}/>
                <IconButton
                    size='small'
                    onClick={handleSeePassword}
                    sx={{position:'absolute', right:'0px'}}>
                        {seePassword? <VisibilityOffIcon/> : <VisibilityIcon/>}
                </IconButton>
            </Box>
            <Box component='div' sx={{position:'relative',display:'flex', justifyContent:'space-between', alignItems:'center', width:'100%'}}>
                <Typography> Remenber me <Checkbox/></Typography>
                <Link to='/forgotpassword' className='Link'>forgot password?</Link>
            </Box>
            <Button disabled={isLoading} type='submit' fullWidth variant='contained' size='large'sx={{position:'relative'}} >
                Log in
                <EastIcon sx={{position:'absolute', right:'20px'}}/>
            </Button>
            <Link to={'/register'} className='Link'>Don't have an account? Register!</Link>
        </Paper>
    </Box>
  )
}

export default LoginPage