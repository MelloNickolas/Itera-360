import { Link } from 'react-router-dom';

const Home = () => {
  return (
    <div>
      <h1>Bem-vindo à Página Inicial</h1>
      <Link to="/dashboard">Ir para o Dashboard (Protegido)</Link>
    </div>
  );
};

export default Home;
