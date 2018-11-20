import { UserType } from './../app/models/usertype';
export const environment = {
    production: false,
    userType: UserType.USER,
    SOCKET_ENDPOINT: 'https://whisper-megagenial.us-east-1.elasticbeanstalk.com:8080'
    // SOCKET_ENDPOINT: 'http://localhost:8080'
};
  