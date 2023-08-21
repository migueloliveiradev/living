import { User } from "interfaces/user/user";

export interface Post {
    id: number;
    content: string;
    created_at: string;
    user_id: number;
    user: User | null;
    likes: Array<Like>;
}



export interface Like {
    id: number;
    user_id: number;
    user: User | null;
    post_id: number;
    post: Post | null;
    created_at: string;
}

export interface Attachment {
    id: number;
    url: string;
    post_id: number;
    post: Post | null;
    attachment_type: string
}

export interface Group {
    id: number;
    name: string;
    owner_id: number;
    owner: User | null;
    description: string;
    photo_url: string;
    banner_url: string;
    created_at: string;
    updated_at: string;
    posts: Array<Post>;
    users: Array<User>;
}