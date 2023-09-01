import { User } from "interfaces/user/user";

export interface Message {
    id: number;
    content: string;
    created_at: string;
    sender_id: number;
    receiver_id: number;
    sender: User | null;
    receiver: User | null;
}

export interface MessageRequest {
    content: string;
    receiver_id: number;
}