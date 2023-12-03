import 'package:flutter/material.dart';
import 'package:signalr_netcore/signalr_client.dart';

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Flutter Demo',
      theme: ThemeData(
        colorScheme: ColorScheme.fromSeed(seedColor: Colors.deepPurple),
        useMaterial3: true,
      ),
      home: const MyHomePage(title: 'Flutter Demo Home Page'),
    );
  }
}

class MyHomePage extends StatefulWidget {
  const MyHomePage({super.key, required this.title});
  final String title;

  @override
  State<MyHomePage> createState() => _MyHomePageState();
}

class _MyHomePageState extends State<MyHomePage> {
  int _counter = 0;
  double width = 100.0, height = 100.0;
  late Offset position;
  late HubConnection hubConnection;

  void handleNewPosition() {}

  void initSignalR() {
    hubConnection =
        HubConnectionBuilder().withUrl("https://localhost:9011/chat").build();
    hubConnection.onclose(({error}) {
      print("Connection close");
    });
    hubConnection.on("ReceiveNewPosition", handleNewPosition());
  }

  @override
  void initState() {
    // TODO: implement initState
    super.initState();
    initSignalR();
    position = Offset(0.0, -20.0);
  }

  void _incrementCounter() {
    setState(() {
      _counter++;
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text(widget.title),
      ),
      body: Stack(
        children: [
          Positioned(
            left: position.dx,
            top: position.dy,
            child: Draggable(
                feedback: Container(
                  width: width,
                  height: height,
                  color: Colors.red[900],
                  child: Center(
                      child: Text(
                    'Move me',
                    style: TextStyle(color: Colors.white),
                  )),
                ),
                child: Container(
                  width: width,
                  height: height,
                  color: Colors.blue,
                  child: Center(
                      child: Text(
                    'Move me',
                    style: TextStyle(color: Colors.white),
                  )),
                )),
                onD
          )
        ],
      ),
      floatingActionButton: FloatingActionButton(
        onPressed: _incrementCounter,
        tooltip: 'Increment',
        child: const Icon(Icons.add),
      ),
    );
  }
}
