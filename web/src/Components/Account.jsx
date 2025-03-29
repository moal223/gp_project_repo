import React, { useEffect, useState } from 'react';
import { useNavigate, Link } from 'react-router-dom';
import { getToken } from '../Helper/Tokens';
import { jwtDecode } from 'jwt-decode';
import { useAuthContext } from './contextAuth';

const Account = () => {
  const [userInfo, setUserInfo] = useState({ fullName: '', email: '' });
  const navigate = useNavigate();

  useEffect(() => {
    const token = getToken('access');
    if (token) {
      const decoded = jwtDecode(token);
      setUserInfo({
        fullName: decoded.sub,
        email: decoded.email,
      });
    } else {
      navigate('/login');
    }
  }, [navigate]);

  const { handleLogout } = useAuthContext();

  return (
    <div className="flex flex-row items-center justify-center min-h-screen bg-gray-100 px-6">
      <div className="bg-white p-24 shadow-xl rounded-xl w-full max-w-4xl ">
        <h1 className="text-3xl font-bold text-blue-800 mb-6">Account Settings</h1>

        <div className=" flex flex-row mb-4 ml-4">
          <h2 className="text-lg font-medium text-blue-600 px-2"> Name:</h2>
          <p className="text-gray-900 font-bold">{userInfo.fullName}</p>
        </div>

        <div className="flex flex-row mb-4 ml-4">
          <h2 className="text-lg font-medium text-blue-600 px-2">Email:</h2>
          <p className="text-gray-900 font-semibold">{userInfo.email}</p>
        </div>

        {/* "Try Free Now" Button */}

        {/* Logout Button */}
        <button
          onClick={handleLogout}
          className="mt-4 w-full bg-red-500 hover:bg-red-600 text-white font-medium py-2 px-4 rounded-lg transition"
        >
          Logout
        </button>
      </div>
    </div>
  );
};

export default Account;
