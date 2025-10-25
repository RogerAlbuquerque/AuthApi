import { FaGoogle, FaLinkedinIn, FaFacebookF } from "react-icons/fa";

import React from "react";
function SignInForm() {
    const [state, setState] = React.useState({
        Email: "",
        PasswordHash: ""
    });
    const handleChange = (evt: { target: { value: any; name: any; }; }) => {
        const value = evt.target.value;
        setState({
            ...state,
            [evt.target.name]: value
        });
    };

    const handleOnSubmit = async (evt: { preventDefault: () => void; }) => {
        evt.preventDefault();

        // const { Email, PasswordHash } = state;

        // if(Email === "teste@gmail.com" && PasswordHash === "1234") {
        //    alert(`You are login with Email: ${Email} and PasswordHash: ${PasswordHash}`);
        //     return;
        // }
        // else{
        //     alert("Wrong Email or PasswordHash");
        // }
        try {
            window.location.href = "http://localhost:5005/Auth/login";

            // const response = await fetch('http://localhost:5005/Auth/login', {
            //     method: 'POST',
            //     headers: {
            //         'Content-Type': 'application/json',
            //     },
            //     body: JSON.stringify({ Email, PasswordHash })
            // });

            // if (response.ok) {
            //     const data = await response.json();
            //     alert('Login successful!');
            //     // You can store the token here if the API returns one
            //     // localStorage.setItem('token', data.token);
            //     console.log('Response data:', data);
            // } else {
            //     alert('Invalid credentials');
            //     console.log(response.status);
            // }
        } catch (error) {
            alert('Error connecting to the server');
            console.error('Error:', error);
        }

        for (const key in state) {
            setState({
                ...state,
                [key]: ""
            });
        }
    };

    return (
        <div className="form-container sign-in-container">
            <form onSubmit={handleOnSubmit}>
                <h1>Sign in</h1>
                <div className="social-container">
                    <a href="#" className="social">
                        <i className="fab fa-facebook-f" >
                            <FaFacebookF />
                        </i>
                    </a>
                    <a href="#" className="social">
                        <i className="fab fa-google-plus-g" >
                            <FaGoogle />
                        </i>
                    </a>
                    <a href="#" className="social">
                        <i className="fab fa-linkedin-in" >
                            <FaLinkedinIn />
                        </i>
                    </a>
                </div>
                <span>or use your account</span>
                <input
                    type="Email"
                    placeholder="Email"
                    name="Email"
                    value={state.Email}
                    onChange={handleChange}
                />
                <input
                    type="PasswordHash"
                    name="PasswordHash"
                    placeholder="PasswordHash"
                    value={state.PasswordHash}
                    onChange={handleChange}
                />
                <a href="#">Forgot your PasswordHash?</a>
                <button>Sign In</button>
            </form>
        </div>
    );
}

export default SignInForm;
