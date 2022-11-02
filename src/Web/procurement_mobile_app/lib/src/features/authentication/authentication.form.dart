import 'package:flutter/material.dart';

class AuthenticationForm extends StatefulWidget {
  AuthenticationForm({Key? key, required this.login}) : super(key: key);
  final Function login;
  final userNameController = TextEditingController();
  final passwordController = TextEditingController();
  @override
  State<AuthenticationForm> createState() => _AuthenticationFormState();
}

class _AuthenticationFormState extends State<AuthenticationForm> {
  @override
  Widget build(BuildContext context) {
    return Form(
      child: Container(
        padding: const EdgeInsets.only(left: 24, right: 24, top: 80, bottom: 0),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            TextFormField(
              decoration: const InputDecoration(
                prefixIcon: Icon(Icons.person_outline_outlined),
                labelText: "Email",
                border: OutlineInputBorder(),
              ),
              controller: widget.userNameController,
              onChanged: (value) {
                widget.userNameController.text = value;
              },
              validator: (value) {
                if (value == null || value.isEmpty) {
                  return 'Please enter some text';
                }
                return null;
              },
            ),
            const SizedBox(height: 16),
            TextFormField(
              decoration: const InputDecoration(
                prefixIcon: Icon(Icons.fingerprint),
                labelText: "Password",
                border: OutlineInputBorder(),
              ),
              controller: widget.passwordController,
            ),
            const SizedBox(height: 16),
            SizedBox(
              width: double.infinity,
              child: ElevatedButton(
                onPressed: () {
                  widget.login(widget.userNameController.text,
                      widget.passwordController.text);
                },
                child: const Text("Login"),
              ),
            )
          ],
        ),
      ),
    );
  }
}
