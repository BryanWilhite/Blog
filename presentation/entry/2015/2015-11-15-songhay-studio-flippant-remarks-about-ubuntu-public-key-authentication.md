---json
{
  "documentId": 0,
  "title": "Songhay Studio: flippant remarks about Ubuntu public key authentication",
  "documentShortName": "2015-11-15-songhay-studio-flippant-remarks-about-ubuntu-public-key-authentication",
  "fileName": "index.html",
  "path": "./entry/2015-11-15-songhay-studio-flippant-remarks-about-ubuntu-public-key-authentication",
  "date": "2015-11-16T06:03:16.182Z",
  "modificationDate": "2015-11-16T06:03:16.182Z",
  "templateId": 0,
  "segmentId": 0,
  "isRoot": false,
  "isActive": true,
  "sortOrdinal": 0,
  "clientId": "2015-11-15-songhay-studio-flippant-remarks-about-ubuntu-public-key-authentication",
  "tag": "{\r\n  \"extract\": \"The goals of public key authentication include disallowing logging in to a remote server as root and using ssh a public key (with an optional passphrase) instead of server passwords to login (with a user of reduced privileges—with sudo powers).The public...\"\r\n}"
}
---

# Songhay Studio: flippant remarks about Ubuntu public key authentication

The goals of public key authentication include disallowing logging in to a remote server as root and using `ssh` a public key (with an optional passphrase) instead of server passwords to login (with a user of reduced privileges—with `sudo` powers).

The public key comes from your local machine (in `.ssh/id_rsa.pub`) and is sent to the remote machine with this command:

```console
ssh-copy-id root@555.555.5.55
```

Your user with reduced privileges recognizes the key when `.ssh/authorized_keys` contains the key. To disallow root login (which should be done after testing the reduced-privileges user), find this line in `/etc/ssh/sshd_config` on the remote server:

```console
PermitRootLogin yes
```

To seal the breach, change this line to:

```console
PermitRootLogin no
```

All the work on the remote server should be punctuated with this:

```console
service ssh restart
```

The details of this whole process is covered quite well in “[Initial Server Setup with Ubuntu 14.04](https://www.digitalocean.com/community/tutorials/initial-server-setup-with-ubuntu-14-04).”

@[BryanWilhite](https://twitter.com/BryanWilhite)
