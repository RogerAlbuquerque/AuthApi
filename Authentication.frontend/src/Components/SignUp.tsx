import React from "react";
import { FaFacebookF, FaGoogle, FaLinkedinIn } from "react-icons/fa";
function SignUpForm() {
    const [state, setState] = React.useState({
        name: "",
        email: "",
        password: ""
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

        const requestData = {
            Username: state.name,
            Email: state.email,
            PasswordHash: state.password
        };
        try {
            const response = await fetch('http://localhost:5005/Auth/register', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(requestData)
            });
            console.log(response)
            if (response.ok) {
                const data = await response.json();
                alert('Sign-in successful!');
                console.log('Response data:', data);
            } else {
                alert('Invalid credentials');
                console.log(response.status);
            }
        } catch (error) {
            alert('Error connecting to the server');
        }
        for (const key in state) {
            setState({
                ...state,
                [key]: ""
            });
        }
    };

    return (
        <div className="form-container sign-up-container">
            <form onSubmit={handleOnSubmit}>
                <h1>Create Account</h1>
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
                <span>or use your email for registration</span>
                <input
                    type="text"
                    name="name"
                    value={state.name}
                    onChange={handleChange}
                    placeholder="Name"
                />
                <input
                    type="email"
                    name="email"
                    value={state.email}
                    onChange={handleChange}
                    placeholder="Email"
                />
                <input
                    type="password"
                    name="password"
                    value={state.password}
                    onChange={handleChange}
                    placeholder="Password"
                />
                <button>Sign Up</button>
            </form>
        </div>
    );
}

export default SignUpForm;
