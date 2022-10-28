import React, { Component } from 'react'
import MainRouter from './MainRouter'
import { BrowserRouter as Router } from "react-router-dom";

export default class App extends Component {
  render() {
    return (
      <>
      <Router>
						<MainRouter />	
					</Router>
          </>
    )
  }
}
