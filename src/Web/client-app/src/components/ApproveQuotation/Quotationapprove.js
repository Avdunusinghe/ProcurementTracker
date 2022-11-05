import React from "react";
import emailjs from "emailjs-com";

/**
 * @author
 * @function
 **/

const emailer = () => {
  function sendEmail(e) {
    e.preventDefault();

    emailjs
      .sendForm(
        "service_a9wiohc",
        "template_9gtqp5c",
        e.target,
        "user_EKnL5flUnkm7F9eyeeFQq"
      )
      .then((res) => {
        console.log(res);
      })
      .catch((err) => console.log(err));
  }
  return (
    <div>
      <div
        className="container boarder"
        style={{ marginTop: "50px", width: "50%" }}
      >
        <h1 style={{ marginTop: "25px" }} className="text-center">
          <b>
            <u>Email Confirmation </u>
          </b>
        </h1>

        <form
          className="row"
          style={{ margin: "55px 85px 75px 100px" }}
          onSubmit={sendEmail}
        >
          <img
             src="https://c.tenor.com/Trqn0AC_d98AAAAC/document-email.gif"
            style={{ height: "50%", width: "50%" }}
          />
          <br />
          <br />
          <label>
            <b>Name of the Supplier</b>
          </label>
          <input type="text" name="name" className="form-control" />

          <label>
            <b>Email</b>
          </label>
          <input
            type="email"
            name="user_email"
            className="form-control"
          ></input>

          <label>
            <b>Site address and Date</b>
          </label>
          <textarea name="message" rows="4" className="form-control" />
          <input
            type="submit"
            value="Send"
            className="form-control btn btn-primary"
            style={{ marginTop: "30px" }}
          />
        </form>
      </div>
    </div>
  );
};
export default emailer;
