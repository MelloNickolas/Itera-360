import React from 'react';
import { Navigate } from 'react-router-dom';

const ProtectedRoute = ({ isAuth, children }) => {
  if (!isAuth) {
    return <Navigate to="/" />;
  }

  return children;
};

export default ProtectedRoute;

// Este componente verifica se o usuário está autenticado. Se não estiver, ele será redirecionado para a página inicial.