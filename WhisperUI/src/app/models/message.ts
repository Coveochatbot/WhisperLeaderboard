import {User} from './user';

export interface Message {
    from?: User;
    content?: any;
    date?: Date;
}