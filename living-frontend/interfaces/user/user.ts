import { Group, Like, Post } from "../posts/post";

export interface User {
    id: number;
    username: string;
    name: string;
    email: string;
    photo_url: string;
    banner_url: string;
    bio: string;
    created_at: string;
    updated_at: string;
    birth_date: string;
    posts: Array<Post>;
    followers: Array<User>;
    following: Array<User>;
    likes: Array<Like>;
    groups: Array<Group>;
}

export interface UserRequest {
    username: string;
    name: string;
    email: string;
    password: string;
    password_confirmation: string;
    birth_date: string;
    bio: string;
}

export interface UserLoginRequest {
    username: string;
    password: string;
}

export interface UserLoginResponse {
    token: string | null;
    success: boolean;
}

export interface UserRegisterResponse {
    token: string | null;
    errors: { [key: string]: any; } | null;
    success: boolean;
}