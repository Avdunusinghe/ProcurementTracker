import 'package:flutter/cupertino.dart';

class AuthenticationModel {
  final String? userName;
  final String? password;

  AuthenticationModel({@required this.userName, @required this.password});

  factory AuthenticationModel.fromJson(Map<String, dynamic> json) {
    return AuthenticationModel(
      userName: json['userName'],
      password: json['password'],
    );
  }
}
