import { useEffect, useState } from 'react';
import { useNavigate } from "react-router";

export default function App() {
    const [User, setUser] = useState({ email: "", name: "" });
    const navigate = useNavigate();
    useEffect(() => {
        async function GetUser() {
            try {
   
                const response = await fetch('http://localhost:5005/Auth/Home', {
                    method: 'GET',
                    credentials: "include",
                    headers: {
                        'Content-Type': 'application/json',
                    },
                });

                if (response.ok) {
                    const data = await response.json();
                    setUser(data);
                    console.log(response.ok);
                }
                else {
                    navigate('/');
                    console.log(response.ok);
                    
                }
            } catch (error) {
                console.error('Error fetching user data:', error);
                navigate('/?login=false');
            }
        }
        GetUser();
    }, []); // ← executa apenas uma vez, quando o componente é montado
    return (
        <div style={{ width: "100vw", height: "100vh", display: "flex", alignItems: "center", flexDirection: "column", justifyContent: "center", color: "Green", fontSize: "5rem" }}>
            <h1>{User.name ? User.name : "LOADING..."}</h1>
            <h1>{User.email}</h1>
        </div>
    )
}

