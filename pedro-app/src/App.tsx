import { useRoutes } from 'react-router-dom';
import routes from './router';
import './App.css';
import NavBar from './commons/NavBar';

function App() {
  const content = useRoutes(routes)
  return (
    <>
      {content}
    </>
  );
}

export default App;
