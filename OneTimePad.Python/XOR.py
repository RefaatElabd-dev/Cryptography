import math

def xor(x, s):
    print(x, 'xor', s, '=', bin(x), 'xor', bin(s), '=', bin(x^s), '=', x^s)
    #print((x - s)% math.pow(2, math.floor(math.log2(max(x, s))) + 1))


xor(4, 8)
xor(4, 4)
xor(255, 1)
xor(255, 128)
xor(255, 37)
xor(42, 37)
