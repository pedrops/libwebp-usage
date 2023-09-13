import {
  Grid,
  List,
  ListItem,
  ListItemButton,
  ListItemIcon,
  ListItemText,
  Divider
} from '@mui/material';
import { Outlet, useNavigate } from 'react-router-dom'
import AppBar from '@mui/material/AppBar';
import Box from '@mui/material/Box';
import Toolbar from '@mui/material/Toolbar';
import Typography from '@mui/material/Typography';
import Button from '@mui/material/Button';
import IconButton from '@mui/material/IconButton';
import MenuIcon from '@mui/icons-material/Menu';
import { useContext } from 'react';
import { UserSessionContext } from '../../contexts/authContext';
import useAuth from '../../hooks/useAuth';
import './index.css'
import SideBar from '../../layouts/SideBar';
import Admin from '../../content/pages/Admin';

export default function NavBar() {
  const { isLogged } = useContext(UserSessionContext)
  const { LogOut} = useAuth()
  const navigate = useNavigate()
  const handleClick = () => {
    isLogged? LogOut() : navigate('/login')
  }

  return (
    <>
    <Box component='main' maxHeight='100vh' sx={{overflowX:'hidden', overflowY:'scroll'}}>
      <AppBar position="static">
        <Toolbar>
          <IconButton
            size="large"
            edge="start"
            color="inherit"
            aria-label="menu"
            sx={{ mr: 2, display:{md:'none'} }}
          >
            <MenuIcon />
          </IconButton>
          <Typography variant="h6" component="div" sx={{ flexGrow: 1 }}>
            Blue Mountain
          </Typography>
          {isLogged && <Button color='inherit' onClick={() => navigate('admin')}>Admin</Button>}
          <Button onClick={handleClick} color="inherit">{isLogged? 'Logout' : 'Login'}</Button>
        </Toolbar>
      </AppBar>
      <Grid container>
        <SideBar/>
        <Grid item md={10} sx={{height:'100%', pl:2}}>
          <Admin/>
        </Grid>
      </Grid>
    </Box>
    </>
  );
}
