import React, { Component } from 'react';
import axios from "axios";
import "./mystyles2.css";

export default class pendingQuatation extends Component {
  constructor(props) {
		super(props);

		this.state = {
			posts: [],
		};
	}
	componentDidMount() {
		this.retrievePosts();
	}

	retrievePosts() {
		axios.post("https://localhost:7088/api/Order/getPurchaseRequests", {"purchaseRequestStatus": 1}).then((res) => {
			if (res.data) {
				console.log(res.data)
				this.setState({
					posts: res.data,
				});
				console.log(this.state.posts);
			}
		});
	}

	
    

	filterData(posts, searchKey) {
		const result = posts.filter(
			(post) => post.name.toLowerCase().includes(searchKey) || post.town.toLowerCase().includes(searchKey)
		);
		this.setState({ posts: result });
	}

	handleSearchArea = (e) => {
		const searchKey = e.currentTarget.value;

		axios.post("https://localhost:7088/api/Order/getPurchaseRequests",{"purchaseRequestStatus": 1
	}).then((res) => {
			if (res.data) {
				this.filterData(res.data, searchKey);
			}
		});
	};
  render() {
    return (
      <div>
        
        <div>
				<div className="container">
					<br />
					<div style={{ fontSize: "15px" }}>
						<a href="/" class="previous" style={{ color: "white" }}>
							&laquo; Previous
						</a>
					</div>
					<div className="text-center">
						<h2 className="adminletter" style={{ fontSize: "40px" }}>
							{" "}
							Pending Quotations{" "}
						</h2>
					</div>
					<br/>
					<div className="col-md-6 mb-4">
						<form class="form-inline">
							<i class="fas fa-search" aria-hidden="true"></i>
							<input
								className="form-control form-control-sm ml-3 w-75"
								type="search"
								placeholder="search"
								name="searchQuery"
								onChange={this.handleSearchArea}
							></input>
						</form>
					</div>

					<table class="table table-striped" style={{ fontSize: "17px" }}>
						<thead>
							<tr>
								<th scope="col">Order No</th>
								<th scope="col">Material</th>
								<th scope="col">Order Date</th>
								<th scope="col">QTY</th>
								<th scope="col">Description</th>
								<th scope="col">Action</th>
							</tr>
						</thead>
						<tbody>
							{this.state.posts.map((posts, index) => (
								<tr key={index}>
									<th scope="row">{index + 1}</th>
									<td>
										<a href={`/order/post/${posts._id}`} style={{ textDecoration: "none" }}>
											{posts.purchaseRequestProductItems[0].productName}
										</a>
									</td>
									<td>{posts.requiredDeliveryDate}</td>
									<td>{posts.purchaseRequestProductItems[0].numberOfItem}</td>
									<td>{posts.description}</td>
									

									<td>
										<a className="btn btn-primary" href={`/approve/${posts.id}`}>
											<i className="fas fa-eye"> Proceed</i>
										</a>
										&nbsp;
										
									</td>
								</tr>
							))}
						</tbody>
						<br />
						<br />
					</table>
			
				
				</div>

				<div class="center2">
					<div class="pagination">
						<a href="#">&laquo;</a>

						<a href="#" class="active">
							1
						</a>
						<a href="#">2</a>
						<a href="#">&raquo;</a>
					</div>
				</div>
      </div>
      </div>
    )
  }
}
