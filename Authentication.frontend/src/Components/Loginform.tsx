import { useState, type SetStateAction } from "react";
import "../Style/style.css";
import SignUpForm from "../Components/SignUp";
import SignInForm from "../Components/SignIn";
import { useLocation } from "react-router";

export default function LoginForm() {
  const [type, setType] = useState("signIn");
  const location = useLocation();
  const searchParams = new URLSearchParams(location.search);
  const loggedError = searchParams.get("login");


  const handleOnClick = (text: SetStateAction<string>) => {
    if (text !== type) {
      setType(text);
      return;
    }
  };
  const containerClass =
    "container " + (type === "signUp" ? "right-panel-active" : "");
  return (
    <div className="App">
      <p style={{color:"red", fontSize:"2em"}}>{loggedError == "false" && "Acesso negado login necessário"}</p>
      <h2>Sign in/up Form</h2>
      <div className={containerClass} id="container">
        <SignUpForm />
        <SignInForm />
        <div className="overlay-container">
          <div className="overlay">
            <div className="overlay-panel overlay-left">
              <h1>Welcome Back!</h1>
              <p>
                To keep connected with us please login with your personal info
              </p>
              <button
                className="ghost"
                id="signIn"
                onClick={() => handleOnClick("signIn")}
              >
                Sign In
              </button>
            </div>
            <div className="overlay-panel overlay-right">
              <h1>Hello, Friend!</h1>
              <p>Enter your personal details and start journey with us</p>
              <button
                className="ghost "
                id="signUp"
                onClick={() => handleOnClick("signUp")}
              >
                Sign Up
              </button>
            </div>
          </div>
        </div>
      </div>
    </div>
  )
}

