# Chat-Application-Server

## Overview

I finished my **Introduction to C#** course in fall of 2015. During my winter break, I decided it was time to challenge myself to build my first software project. I figured that winter break could provide me with a deadline, and the goal was to get something finished before my spring semester started. That was this project.

I chose to build a chat client and server to get a basic idea about **networking**. At the time, it was quite a challenging project, since it went above what my previous knowledge was. This is when I learned that improving your programming skills was about taking on projects that are just outside of your reach, and learning how to adapt.

## Chat Client

![client_pic](http://i.imgur.com/UjfZkOL.png)

Originally, this chat client was built for the command prompt (like all my previous applications). I chose to branch out into **windows forms** to learn a little bit about building a **GUI**. In this application, you would see the messages other users send once you are connected to a server.

![settings_pic](http://i.imgur.com/2ngvesY.png)

There is also a settings page that allows you to modify your username, the server IP you are connecting to, and the port number.

## Chat Server

![server_pic](http://i.imgur.com/OkNIHXL.png)

The server is a console application that just shows the connections/disconnections, along with messages being sent by users.

Unfortunately, as I found through troubleshooting with a few friends, the server is prone to break in many ways. An unexpected ping to the server can cause it to crash. If users spam connect/disconnect, or spam messages, the input/output of the server can get clogged up and start showing things multiple times.

## Closing

This application is not anything particularly impressive to an experienced programmer, but it was a massive step in my programming journey. I built it on my own time to what I had considered completion (turns out that there are plenty of bugs, and the server is very fragile), and more importantly, I was able to finish it before my deadline of about 3 weeks.

To this day, I am still very proud of myself for finishing this so early on in my programming career.