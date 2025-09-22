import { render, screen } from "@testing-library/react";
import userEvent from "@testing-library/user-event";
import { MemoryRouter } from "react-router";
import LoginForm from "../Components/Loginform";

function setup() {
  return render(
    <MemoryRouter initialEntries={["/"]}>
      <LoginForm />
    </MemoryRouter>,
  );
}

test("initial state: cannot be in register mode", () => {
  setup();

  const container = document.querySelector("#container");
  expect(container).toBeInTheDocument();
  expect(container).not.toHaveClass("right-panel-active");
});

test("Click on \"Sign Up\" active register mode", async () => {
  const user = userEvent.setup();
  setup();

  const container = document.getElementById("container");
  expect(container).toBeInTheDocument();

  const signUpButton = document.getElementById("signUp") as HTMLButtonElement | null;
  expect(signUpButton).toBeTruthy();

  await user.click(signUpButton!);
  expect(container).toHaveClass("right-panel-active");

  expect(screen.getAllByRole("button", { name: /sign in/i }).length).toBeGreaterThan(0);
  expect(screen.getAllByRole("button", { name: /sign up/i }).length).toBeGreaterThan(0);
});

test("clic on \"Sign In\" after register go back to login mode", async () => {
  const user = userEvent.setup();
  setup();

  const container = document.getElementById("container");
  expect(container).toBeInTheDocument();

  const signUpButton = document.getElementById("signUp") as HTMLButtonElement | null;
  const signInButton = document.getElementById("signIn") as HTMLButtonElement | null;
  expect(signUpButton).toBeTruthy();
  expect(signInButton).toBeTruthy();

  await user.click(signUpButton!);
  expect(container).toHaveClass("right-panel-active");

  await user.click(signInButton!);
  expect(container).not.toHaveClass("right-panel-active");
});

