import { useState } from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import Home from './pages/Home';
import Dashboard from './pages/Dashboard';
import ProtectedRoute from './ProtectedRoute';

function App() {
  // Simulação de autenticação: troque o valor para 'true' quando o usuário estiver logado
  const [isAuth, setIsAuth] = useState(false);

  return (
    <Router>
      <div>
        <button onClick={() => setIsAuth(!isAuth)}>
          {isAuth ? 'Logout' : 'Login'}
        </button>

        <Routes>
          <Route path="/" element={<Home />} />

          {/* A rota dashboard é protegida */}
          <Route
            path="/dashboard"
            element={
              <ProtectedRoute isAuth={isAuth}>
                <Dashboard />
              </ProtectedRoute>
            }
          />
        </Routes>
      </div>
    </Router>
  );
}

export default App;

{/*
O que estamos fazendo aqui?

● Autenticação Simples: Criamos um estado isAuth que controla se o usuário está
logado ou não. Um botão permite alternar entre login e logout (por enquanto, sem
lógica de autenticação real).

● ProtectedRoute: Usamos o ProtectedRoute para proteger o acesso à página
Dashboard. Se isAuth for false, o usuário é redirecionado para a página inicial.  
  
*/}